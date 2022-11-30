using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    private int _score; // スコア
    //private int minusScorepoint = 10; //減少するスコアのポイント
    private int _highScore; //ハイスコア
    private float _time; //経過時間
    [SerializeField] float _maxTime = 100.0f; //制限時間
    private bool ingame = true;
    [SerializeField] Text TimerText;
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        _time = _maxTime;
        _highScore = PlayerPrefs.GetInt("score");
    }

    // Update is called once per frame
    void Update()
    {
        TimerText.text = ((int)_time).ToString()+ "s";
        if(_highScore < _score) //もしハイスコアを更新したら
        {
            _highScore = _score; //ハイスコアをスコアに変え、セーブする
            PlayerPrefs.SetInt("score", _highScore);
            PlayerPrefs.Save();
        }
        if(ingame == true)
        {
            _time -= Time.deltaTime; //タイマー
            if (_time <= 0) //タイムアップ時
            {
                print("gameorver");
                ingame = false;
            }
        }
        Debug.Log(_time);
    }
    public void AddScore(int plusScorepoint) //スコアを増加させるメゾット
    {
        _score += plusScorepoint;
    }
    //public void lowerscore() //スコアを減少させるメゾット
    //{
    //    score -= minusScorepoint;
    //}
}
