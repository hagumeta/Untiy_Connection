using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderLine : MonoBehaviour {

    public Transform point1, point2;
    private Transform line;

    public void Start()
    {
        this.line = this.transform;
    }

    public void SetLine(Vector2 pos1, Vector2 pos2)
    {
        this.point1.position = pos1;
        this.point2.position = pos2;

        this.line.position = (pos2 + pos1) / 2;
        this.line.localScale = new Vector3((pos2 - pos1).magnitude, this.line.localScale.y, this.line.localScale.z);

        this.line.transform.right = (pos2 - pos1).normalized;

    }


    private void Update()
    {
        if (this.point1 != null && this.point2 != null) {
            this.SetLine(this.point1.position, this.point2.position);
        }
    }
}
/*
public int layer
{
    get
    {
        return this.gameObject.layer;
    }
    set
    {
        this.SetLayer(this.gameObject, value);
    }
}

/// <summary>
/// 対象とその子全てにレイヤーを一括設定する
/// </summary>
/// <param name="target"></param>
/// <param name="layer"></param>
private void SetLayer(GameObject target, int layer)
{
    target.layer = layer;
    if (target.transform.childCount <= 0)
    {
        return;
    }
    for (int i = 0; i < target.transform.childCount; i++)
    {
        this.SetLayer(target.transform.GetChild(i).gameObject, layer);
    }
}
*/
