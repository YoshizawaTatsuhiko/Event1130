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
        int n = Random.Range(0, _meteorite.Length);
        _timer += Time.deltaTime;

        if(_timer > _interval)
        {
            Instantiate(_meteorite[n], transform.position, Quaternion.identity);
        }
    }
}
