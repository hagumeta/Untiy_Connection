using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public class ConnectPointController : MonoBehaviour {

    public GameObject BurstEffectObject;
    public GameObject ScoreTextEffect;

    [System.NonSerialized]
    public bool IsConnected;

    private Animator animator;

    public int Score;


    protected virtual void Start()
    {
        this.IsConnected = false;
        this.animator = this.GetComponent<Animator>();
    }


    virtual public void Connected()
    {
        if (this.IsConnected) return;
        this.IsConnected = true;
    }


    /// <summary>
    /// コネクトが確立された後に呼ばれる
    /// </summary>
    virtual public void Burst()
    {
        this.GainScore(this.Score);
        Instantiate(this.BurstEffectObject, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }


    private void Update()
    {
        this.animator.SetBool("IsConnected", this.IsConnected);   
    }
    

    protected void GainScore(int score)
    {
        var scoreController = GameObject.Find("StageController").GetComponent<StageScoreController>();
        scoreController.AddScore(score);

        var text = Instantiate(this.ScoreTextEffect).GetComponent<ScoreTextEffect>();
        text.transform.position = this.transform.position;
        text.Score = score;
    }
}