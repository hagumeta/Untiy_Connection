﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PointConnector : InputPointer {
    public GameObject LineObject;
    List<Transform> ConnectionTransform = new List<Transform>();
    List<Transform> ConnectionLineTransform = new List<Transform>();

    private Transform beforeConnectionPoint;
    private bool isActivate = false;

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
            if (!connect.IsConnected)
            {
                connect.Connected();
                this.ConnectionTransform.Add(connect.transform);
                if (ConnectionTransform.Count >= 2)
                {
                    var lineObj = Instantiate(this.LineObject);
                    var line = lineObj.GetComponent<CylinderLine>();
                    line.point1 = this.beforeConnectionPoint;
                    line.point2 = connect.transform;


                    this.ConnectionLineTransform.Add(lineObj.transform);
                }

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
            this.transform.position = new Vector3(1000, 10000, 10000);

            this.ResetConnection();
            Destroy(this.gameObject);
        }
    }

    protected override void MoveTouchPosition()
    {
        base.MoveTouchPosition();
    }

    protected virtual void EndConnection()
    {
        StartCoroutine(this.DeleteConnectPoints());
        this.isActivate = false;
    }

    protected virtual void StartConnection()
    {
        this.isActivate = true;
    }
    
    private IEnumerator DeleteConnectPoints()
    {
        yield return new WaitForSeconds(0.5f);

        foreach (var lineObj in ConnectionLineTransform)
        {
            yield return new WaitForSeconds(0.5f);

            var line = lineObj.GetComponent<CylinderLine>();
            if (line.point1 != null) {
                line.point1.GetComponent<ConnectPointController>().Burst();
                yield return new WaitForSeconds(0.5f);
            }

            if (line.point2 != null) {
                line.point2.GetComponent<ConnectPointController>().Burst();
            }
            Destroy(lineObj.gameObject);
        }
    }

    private void ResetConnection()
    {
        foreach (var lineObj in ConnectionLineTransform)
        {
            var line = lineObj.GetComponent<CylinderLine>();
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
    }
}