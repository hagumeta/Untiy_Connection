using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LineSegmentsIntersection;

public class ConnectLine : CylinderLine {

    public GameObject CrossedEffect;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ConnectLine")
        {
            ConnectLine otherLine = collision.GetComponent<ConnectLine>();
            if (otherLine)
            {
                //交点を求める．
                Vector2 intersection;
                if (Math2d.LineSegmentsIntersection(this.point1.position, this.point2.position, otherLine.point1.position, otherLine.point2.position, out intersection))
                {
                    Instantiate(this.CrossedEffect, intersection, Quaternion.identity);
                }
            }
        }
    }
}