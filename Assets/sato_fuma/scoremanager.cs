using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _score; // スコア
    //private int minusScorepoint = 10; //減少するスコアのポイント
    private int _highScore; //ハイスコア
    private float _time; //経過時間
    private float _maxTime = 100.0f; //制限時間
    private bool ingame = true; 
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(_highScore < _score) //もしハイスコアを更新したら
        {
            _highScore = _score; //ハイスコアをスコアに変え、セーブする
            PlayerPrefs.SetInt("score", _highScore);
            PlayerPrefs.Save();
        }
        if(ingame == true)
        {
            _time += Time.deltaTime; //タイマー
            if (_maxTime < _time) //タイムアップ時
            {
                print("gameorver");
                ingame = false;
            }
        }
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
