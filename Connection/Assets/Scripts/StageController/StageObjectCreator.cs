using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageObjectCreator : MonoBehaviour {

    public GameObject Prefab;

    private void Start()
    {
        var a = Instantiate(this.Prefab, this.transform.parent);
        a.transform.localScale = this.transform.localScale;
        a.transform.position = this.transform.position;
        a.transform.rotation = this.transform.rotation;


        Destroy(this.gameObject);
    }
}