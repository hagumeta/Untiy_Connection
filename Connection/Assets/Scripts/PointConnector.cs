using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointConnector : InputPointer {
    public GameObject LineObject;
    List<Transform> ConnectionTransform = new List<Transform>();
    List<Transform> ConnectionLineTransform = new List<Transform>();

    private Transform beforeConnectionPoint;
    private bool isActivate = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!this.isActivate) return; 
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
    }
    protected override void HideSelfPointer()
    {
        if (this.isActivate) {
            this.transform.position = new Vector3(1000, 10000, 10000);
            StartCoroutine(this.DeleteConnectPoints());
            this.isActivate = false;
        }
    }

    protected override void MoveTouchPosition()
    {
        this.isActivate = true;
        base.MoveTouchPosition();
    }


    private IEnumerator DeleteConnectPoints()
    {
        yield return new WaitForSeconds(1f);

        foreach (var lineObj in ConnectionLineTransform)
        {
            yield return new WaitForSeconds(1f);

            var line = lineObj.GetComponent<CylinderLine>();
            if (line.point1 != null) {
                Destroy(line.point1.gameObject);
                yield return new WaitForSeconds(1f);
            }

            if (line.point2 != null) {
                Destroy(line.point2.gameObject);
            }
            Destroy(lineObj.gameObject);
        }
    }
}
