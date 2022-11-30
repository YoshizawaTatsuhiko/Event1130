using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    [Tooltip("���˂����")]
    [SerializeField] private float _reflectPower = 1f;
    [Tooltip("Layer�̔ԍ�")]
    [SerializeField] private int _layerNum = 0;


    private void OnCollisionEnter2D(Collision2D col)
    {
        //���������I�u�W�F�N�g�𒵂˕Ԃ�
        Debug.Log("���˕Ԃ��܂�");
        var hitRb = col.gameObject.GetComponent<Rigidbody2D>();
        var reflect = Vector2.Reflect(hitRb.velocity, transform.up);
        //Vector2.Reflect(a, b)
        //a...���˃x�N�g��
        //b...���������ʂ̖@���x�N�g��(���K������Ă���K�v������)

        hitRb.velocity = reflect * _reflectPower;
        col.gameObject.layer = _layerNum;
    }
}
