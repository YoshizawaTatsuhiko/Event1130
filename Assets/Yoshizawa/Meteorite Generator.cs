using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class MeteoriteGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("隕石のPrefab")]
    private GameObject[] _meteorite = default;
    [SerializeField, Tooltip("隕石を降らせる間隔")]
    private float _interval = 1f;
    /// <summary>時間を計測するタイマー</summary>
    private float _timer = 0f;
    /// <summary>隕石を降らせる範囲</summary>
    private BoxCollider2D _box;

    private void Start()
    {
        _box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        int n = Random.Range(0, _meteorite.Length);
        _timer += Time.deltaTime;

        if(_timer > _interval)
        {
            Instantiate(_meteorite[n], transform.position, Quaternion.identity);
        }
    }
}
