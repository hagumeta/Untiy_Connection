using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleConnectPointController : ConnectPointController {

    private int ConnectedCount;

    public int ScoreOfSecondConnected;

    override protected void Start()
    {
        base.Start();
        this.ConnectedCount = 0;
    }

    public override void Connected()
    {
        this.ConnectedCount++;
        if (this.ConnectedCount >= 2) {
            base.Connected();
        }
    }

    public override void Burst()
    {
        var a = Instantiate(this.BurstEffectObject);
        a.transform.position = this.transform.position;
        this.ConnectedCount--;

        if (this.ConnectedCount <= 0)
        {
            this.GainScore(this.IsConnected ? this.ScoreOfSecondConnected : this.Score);
            Destroy(this.gameObject);
        }
        else
        {
            this.GainScore(this.Score);
        }
    }
}