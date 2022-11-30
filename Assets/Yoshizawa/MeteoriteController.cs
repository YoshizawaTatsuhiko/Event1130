using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]

public class MeteoriteController : MonoBehaviour
{
    [SerializeField, Tooltip("隕石の落ちてくる速さ")]
    private float _speed = 1f;
    [SerializeField, Tooltip("スコア")]
    private int _score = 0;
    /// <summary>Playerの情報</summary>
    private GameObject _player;
    /// <summary>Rigidbody2D型の変数</summary>
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
