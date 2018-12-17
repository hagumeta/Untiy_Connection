using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextEffect : MonoBehaviour {
    public Text ScoreText;



    public int Score
    {
        set => this.ScoreText.text = value.ToString();
    }

    
	void Start () {
        Vector3 scale = this.transform.localScale;
        this.transform.parent = GameObject.Find("Canvas_Effect").transform;
        this.transform.localScale = scale;
        Destroy(this.gameObject, 2f);
	}
}
