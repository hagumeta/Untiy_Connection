using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ConnectPointController : MonoBehaviour {

    [System.NonSerialized]
    public bool IsConnected = false;

    virtual public void Connected()
    {
        if (this.IsConnected) return;
        this.IsConnected = true;

        this.GetComponent<SpriteRenderer>().color = Color.red;
    }
}