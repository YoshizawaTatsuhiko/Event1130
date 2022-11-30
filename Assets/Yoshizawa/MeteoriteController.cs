using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]

public class MeteoriteController : MonoBehaviour
{
    [SerializeField, Tooltip("è¦Î‚Ì—‚¿‚Ä‚­‚é‘¬‚³")]
    private float _speed = 1f;
    [SerializeField, Tooltip("ƒXƒRƒA")]
    private int _score = 0;
    /// <summary>Player‚Ìî•ñ</summary>
    private GameObject _player;
    /// <summary>Rigidbody2DŒ^‚Ì•Ï”</summary>
    private Rigidbody2D _rb;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
        transform.up = _player.transform.position;
        Vector2 vec = _player.transform.position - transform.position;
        _rb.velocity = vec * _speed;
    }
}
