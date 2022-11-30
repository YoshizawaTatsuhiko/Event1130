using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    [Tooltip("反射する力")]
    [SerializeField] private float _reflectPower = 1f;
    [Tooltip("Layerの番号")]
    [SerializeField] private int _layerNum = 0;


    private void OnCollisionEnter2D(Collision2D col)
    {
        //当たったオブジェクトを跳ね返す
        Debug.Log("跳ね返します");
        var hitRb = col.gameObject.GetComponent<Rigidbody2D>();
        var reflect = Vector2.Reflect(hitRb.velocity, transform.up);
        //Vector2.Reflect(a, b)
        //a...入射ベクトル
        //b...当たった面の法線ベクトル(正規化されている必要がある)

        hitRb.velocity = reflect * _reflectPower;
        col.gameObject.layer = _layerNum;
    }
}
