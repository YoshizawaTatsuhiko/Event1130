using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player�̋���
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Tooltip("�ړ����x")]
    [SerializeField] private float _moveSpeed = 1f;
    [Tooltip("�e�X�g�p�̖��G���")]
    [SerializeField] private bool _isGodMode;

    /// <summary> Rigidbody2D </summary>
    private Rigidbody2D _rb2d;
    /// <summary> Player��Animation </summary>
    private Animator _anim;
    /// <summary> Animation���s���ɁA���͂�؂� </summary>
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
    /// �����o��(AnimationEvent�Ŏ��s)
    /// </summary>
    public void SetMirror()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    /// <summary>
    /// �����d����(AnimationEvent�Ŏ��s)
    /// </summary>
    public void CloseMirror()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        _isInput = true;
    }

    public void GameOver()
    {
        _isInput = false;
        //ScoreManager��GameOver�̒ʒm
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
