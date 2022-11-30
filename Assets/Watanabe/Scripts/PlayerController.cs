using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerの挙動
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Tooltip("移動速度")]
    [SerializeField] private float _moveSpeed = 1f;
    [Tooltip("テスト用の無敵状態")]
    [SerializeField] private bool _isGodMode;

    /// <summary> Rigidbody2D </summary>
    private Rigidbody2D _rb2d;
    /// <summary> PlayerのAnimation </summary>
    private Animator _anim;
    /// <summary> Animation実行中に、入力を切る </summary>
    private bool _isInput = true;
    private ScoreManager _manager;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _manager = GameObject.Find("ScoreObject").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isInput == true)
        {
            var hol = Input.GetAxisRaw("Horizontal");

            _anim.SetFloat("MoveSpeed", Mathf.Abs(hol));
            _anim.SetBool("MirrorSet", false);
            _rb2d.velocity = new Vector2(hol * _moveSpeed, _rb2d.velocity.y);

            if (hol != 0)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                if (hol > 0)
                {
                    var scale = transform.localScale;
                    scale.x = -1;
                    transform.localScale = scale;
                }
                else if (hol < 0)
                {
                    var scale = transform.localScale;
                    scale.x = 1;
                    transform.localScale = scale;
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                _anim.SetBool("MirrorSet", true);
                _isInput = false;
            }
        }
    }

    /// <summary>
    /// 鏡を出す(AnimationEventで実行)
    /// </summary>
    public void SetMirror()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    /// <summary>
    /// 鏡を仕舞う(AnimationEventで実行)
    /// </summary>
    public void CloseMirror()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        _isInput = true;
    }

    public void GameOver()
    {
        _isInput = false;
        //ScoreManagerにGameOverの通知
        _manager.Gameover();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (_isGodMode == false)
        {
            if (col.gameObject.CompareTag("Meteorite"))
            {
                _anim.Play("Vanish");
            }
        }
    }
}
