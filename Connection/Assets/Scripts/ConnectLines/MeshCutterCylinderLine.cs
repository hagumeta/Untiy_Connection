using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCutterCylinderLine : CylinderLine {

    public GameObject MeshCutter;

    private void OnDestroy()
    {
        var obj = Instantiate(this.MeshCutter);
        obj.transform.position = this.transform.position + new Vector3(0, 0, 5);
        obj.transform.localScale = new Vector3(this.transform.localScale.x, 0.01f, 10);
    }
}