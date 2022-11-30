using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D), typeof(Rigidbody2D))]

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
    /// <summary>反射してきた隕石のレイヤー</summary>
    private int _layer = 6;
    /// <summary>ScoreManager型の変数</summary>
    private ScoreManager _scoreManager;
    /// <summary>隕石の生存時間</summary>
    private float _lifeTime = 4f;
    [SerializeField, Tooltip("GameObjectが消失時に生成する")]
    private GameObject _onDestroy;
    

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _scoreManager = FindObjectOfType<ScoreManager>();

        _rb = GetComponent<Rigidbody2D>();
        transform.up = _player.transform.position;
        Vector2 vec = _player.transform.position - transform.position;
        _rb.velocity = vec.normalized * _speed;

        Destroy(gameObject, _lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _layer)
        {
            _scoreManager.AddScore(_score);
            if (_onDestroy != null) Instantiate(_onDestroy);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log("OK!");
        }
    }
}
