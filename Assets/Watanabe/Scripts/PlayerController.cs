using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player‚Ì‹““®
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Tooltip("ˆÚ“®‘¬“x")]
    [SerializeField] private float _moveSpeed = 1f;

    /// <summary> Rigidbody2D </summary>
    private Rigidbody2D _rb2d;
    /// <summary> Player‚ÌAnimation </summary>
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
        }
    }

    /// <summary>
    /// ‹¾‚ğo‚·(AnimationEvent‚ÅÀs)
    /// </summary>
    public void SetMirror()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
