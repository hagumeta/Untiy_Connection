using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using LineSegmentsIntersection;


public class PointConnector : InputPointer {
    public GameObject LineObject;
    public GameObject GuideLineObject;

    List<Transform> ConnectionTransform = new List<Transform>();
    List<Transform> ConnectionLineTransform = new List<Transform>();

    private Transform beforeConnectionPoint;
    private bool isActivate = false;


    private CylinderLine myLine;

    override protected void Start()
    {
        base.Start();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!this.isActivate)
        {
            if (collision.tag  == "StartPoint")
            {
                this.StartConnection();
            }
            else
            {
                return;
            }
        }

        var connect = collision.GetComponent<ConnectPointController>();
        if (connect != null)
        {
            if (!connect.IsConnected && this.beforeConnectionPoint != connect.transform)
            {
                connect.Connected();
                this.ConnectionTransform.Add(connect.transform);
                if (ConnectionTransform.Count >= 2)
                {
                    var lineObj = Instantiate(this.LineObject);
                    var line = lineObj.GetComponent<ConnectLine>();
                    line.point1 = this.beforeConnectionPoint;
                    line.point2 = connect.transform;


                    this.ConnectionLineTransform.Add(lineObj.transform);

                }
                
                this.myLine.point1 = connect.transform;
                this.myLine.point2 = this.transform;
                
                this.beforeConnectionPoint = connect.transform;
            }
        }


        if (collision.tag == "EndPoint")
        {
            this.EndConnection();
        }
    }



    protected override void HideSelfPointer()
    {
        if (this.isActivate) {
            this.isActivate = false;
            this.ResetConnection();
        }
    }


    protected override void MoveTouchPosition()
    {
        base.MoveTouchPosition();
    }



    protected virtual void EndConnection()
    {
        Destroy(this.myLine.gameObject);
        StartCoroutine(this.DeleteConnectPoints());
        this.isActivate = false;
    }

    protected virtual void StartConnection()
    {
        this.isActivate = true;
        this.myLine = Instantiate(this.GuideLineObject).GetComponent<CylinderLine>();
        this.myLine.point1 = this.transform;
        this.myLine.point2 = this.transform;
    }

    private IEnumerator DeleteConnectPoints()
    {
        yield return new WaitForSeconds(0.5f);

        float time = 1f/this.ConnectionTransform.Count;

        var lines = this.ConnectionLineTransform.ToArray();
        var points = this.ConnectionTransform.ToArray();
        
        for (int i = 0; i<points.Length; i++)
        {
            points[i].GetComponent<ConnectPointController>().Burst();
            if (i < lines.Length) {
                Destroy(lines[i].gameObject);
            }
            yield return new WaitForSeconds(time);
            
        }
        this.ConnectionLineTransform = new List<Transform>();
        this.ConnectionTransform = new List<Transform>();

        yield return new WaitForSeconds(0.5f);
        StageUnitController.StageComplete();
    }



    private void ResetConnection()
    {
        Destroy(this.myLine.gameObject);

        if (this.ConnectionLineTransform.Count == 0) { return; }

        foreach (var lineObj in this.ConnectionLineTransform)
        {
            var line = lineObj.GetComponent<ConnectLine>();
            if (line.point1 != null)
            {
                line.point1.GetComponent<ConnectPointController>().IsConnected = false;
            }
            if (line.point2 != null)
            {
                line.point2.GetComponent<ConnectPointController>().IsConnected = false;
            }
            Destroy(lineObj.gameObject);
        }

        this.ConnectionLineTransform = new List<Transform>();
        this.ConnectionTransform = new List<Transform>();

    }
}