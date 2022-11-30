using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    [Tooltip("���˂����")]
    [SerializeField] private float _reflectPower = 1f;
    [Tooltip("���˂���覐΂�Layer�̔ԍ�")]
    [SerializeField] private int _reflectLayerNum = 0;
    [Tooltip("���������I�u�W�F�N�g��Layer�̔ԍ�")]
    [SerializeField] private int _hitLayerNum = 0;

    /// <summary> AudioSource </summary>
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        _audio.Play();
        if (col.gameObject.layer == _hitLayerNum)
        {
            //���������I�u�W�F�N�g�𒵂˕Ԃ�
            Debug.Log("���˕Ԃ��܂�");
            var hitRb = col.gameObject.GetComponent<Rigidbody2D>();
            //var reflect = Vector2.Reflect(hitRb.velocity, transform.up);
            //Vector2.Reflect(a, b)
            //a...���˃x�N�g��
            //b...���������ʂ̖@���x�N�g��(���K������Ă���K�v������)

            hitRb.velocity *= _reflectPower * -1;
            //hitRb.velocity = reflect * _reflectPower;
            col.gameObject.layer = _reflectLayerNum;
        }
    }
}
