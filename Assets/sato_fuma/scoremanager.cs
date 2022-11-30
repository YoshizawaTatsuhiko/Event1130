using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _score; // �X�R�A
    //private int minusScorepoint = 10; //��������X�R�A�̃|�C���g
    private int _highScore; //�n�C�X�R�A
    private float _time; //�o�ߎ���
    private float _maxTime = 100.0f; //��������
    private bool ingame = true; 
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(_highScore < _score) //�����n�C�X�R�A���X�V������
        {
            _highScore = _score; //�n�C�X�R�A���X�R�A�ɕς��A�Z�[�u����
            PlayerPrefs.SetInt("score", _highScore);
            PlayerPrefs.Save();
        }
        if(ingame == true)
        {
            _time += Time.deltaTime; //�^�C�}�[
            if (_maxTime < _time) //�^�C���A�b�v��
            {
                print("gameorver");
                ingame = false;
            }
        }
    }
    public void AddScore(int plusScorepoint) //�X�R�A�𑝉������郁�]�b�g
    {
        _score += plusScorepoint;
    }
    //public void lowerscore() //�X�R�A�����������郁�]�b�g
    //{
    //    score -= minusScorepoint;
    //}
}
