using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGUIController : MonoBehaviour {

    [SerializeField]
    private Text ScoreText;
    public StageScoreController ScoreController;

    private void Update()
    {
        if (this.ScoreController != null || this.ScoreText != null)
        {
            this.ScoreText.text = this.ScoreController.Score.ToString();
        }
    }
}