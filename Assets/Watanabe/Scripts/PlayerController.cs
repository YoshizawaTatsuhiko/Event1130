using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player�̋���
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("PlayerStatus�ꗗ")]
    [Tooltip("�ړ����x")]
    [SerializeField] private float _moveSpeed = 1f;
    [Tooltip("�W�����v��")]
    [SerializeField] private float _jumpPower = 1f;

    /// <summary> Rigidbody2D </summary>
    private Rigidbody2D _rb2d;
    /// <summary> �ڒn���� </summary>
    private bool _isGround = false;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        _rb2d.velocity = new Vector2(h * _moveSpeed, _rb2d.velocity.y);

        if (Input.GetButtonDown("Jump") && _isGround == true)
        {
            Debug.Log("Jump");
            _rb2d.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            _isGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {
            _isGround = true;
        }
    }
}
