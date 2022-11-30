using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D)/*, typeof()*/)]

public class MeteoriteController : MonoBehaviour
{
    [SerializeField, Tooltip("覐΂̗����Ă��鑬��")]
    private float _speed = 1f;
    [SerializeField, Tooltip("�X�R�A")]
    private int _score = 0;
    /// <summary>Player�̏��</summary>
    private GameObject _player;
    /// <summary>Rigidbody2D�^�̕ϐ�</summary>
    private Rigidbody2D _rb;
    /// <summary>���˂��Ă���覐΂̃��C���[</summary>
    private int _layer = 6;
    /// <summary>ScoreManager�^�̕ϐ�</summary>
    private ScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
        transform.up = _player.transform.position;
        Vector2 vec = _player.transform.position - transform.position;
        _rb.velocity = vec * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _layer)
        {
            _scoreManager.AddScore(_score);
            Destroy(gameObject);
        }
    }
}
