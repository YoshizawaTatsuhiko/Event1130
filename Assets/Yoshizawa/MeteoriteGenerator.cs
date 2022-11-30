using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class MeteoriteGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("覐΂�Prefab")]
    private GameObject[] _meteorite = default;
    [SerializeField, Tooltip("覐΂��~�点��Ԋu")]
    private float _interval = 1f;
    /// <summary>���Ԃ��v������^�C�}�[</summary>
    private float _timer = 0f;
    /// <summary>覐΂��~�点��͈�</summary>
    private BoxCollider2D _box;

    private void Start()
    {
        _box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float randomX = Random.Range(-_box.size.x / 2, _box.size.x / 2);
        float randomY = Random.Range(-_box.size.y / 2, _box.size.y / 2);
        int n = Random.Range(0, _meteorite.Length);
        _timer += Time.deltaTime;

        if(_timer >= _interval)
        {
            GameObject meteorite = Instantiate(_meteorite[n]);
            meteorite.transform.position =
                new Vector2(randomX + transform.position.x, randomY + transform.position.y);
            _timer = 0f;
        }
    }
}
