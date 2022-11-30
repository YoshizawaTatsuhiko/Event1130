using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int _score; // �X�R�A
    //private int minusScorepoint = 10; //��������X�R�A�̃|�C���g
    private int _highScore; //�n�C�X�R�A
    private float _time; //�o�ߎ���
    [SerializeField] float _maxTime = 100.0f; //��������
    [SerializeField] int _clearScore = 500;
    private bool ingame = true;
    [SerializeField] Text timerText;
    [SerializeField] Text resultScoreText;
    [SerializeField] Text highscoretext;
    [SerializeField] Text resulthighscoretext;
    [SerializeField] Text scoretext;
    [SerializeField] GameObject GameoverPanel;
    [SerializeField] GameObject generator;
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        _time = _maxTime;
        _highScore = PlayerPrefs.GetInt("score");
        highscoretext.text = "�n�C�X�R�A:" + _highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = ((int)_time).ToString() + "s";
        scoretext.text = "�X�R�A:" + _score.ToString();

        if (_highScore < _score) //�����n�C�X�R�A���X�V������
        {
            _highScore = _score; //�n�C�X�R�A���X�R�A�ɕς��A�Z�[�u����
            PlayerPrefs.SetInt("score", _highScore);
            PlayerPrefs.Save();
        }
        if (ingame == true)
        {
            _time -= Time.deltaTime; //�^�C�}�[
            if (_time <= 0) //�^�C���A�b�v��
            {
                AddScore(_clearScore);
                Gameover();
                ingame = false;
            }
        }
    }
    public void AddScore(int plusScorepoint) //�X�R�A�𑝉������郁�]�b�g
    {
        _score += plusScorepoint;
    }
    public void Gameover()
    {
        ingame = false;
        GameoverPanel.SetActive(true);
        resulthighscoretext.text = "�n�C�X�R�A:" + _highScore.ToString();
        resultScoreText.text = "�X�R�A:" + _score.ToString();
        generator.SetActive(false);
    }
}

