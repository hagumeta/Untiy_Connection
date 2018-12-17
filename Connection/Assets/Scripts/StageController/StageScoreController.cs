using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScoreController : MonoBehaviour {


    private int score;
    public int Score
    {
        get => this.score;
        set => this.score = value >= 0 ? value : 0; //マイナスの値は0に統一
    }

	void Start () {
        this.Score = 0;
	}

    /// <summary>
    /// 現在のスコアに指定分加算する(-なら減算もする)
    /// </summary>
    /// <param name="score"></param>
    public void AddScore(int score)
    {
        this.Score += score;
    }
}