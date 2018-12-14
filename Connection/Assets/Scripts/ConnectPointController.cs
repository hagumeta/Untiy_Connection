using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ConnectPointController : MonoBehaviour {

    public GameObject BurstEffectObject;

    [System.NonSerialized]
    public bool IsConnected = false;

    virtual public void Connected()
    {
        if (this.IsConnected) return;
        this.IsConnected = true;

        this.GetComponent<SpriteRenderer>().color = Color.red;
    }



    /// <summary>
    /// コネクトが確立された後に呼ばれる
    /// </summary>
    virtual public void Burst()
    {
        Instantiate(this.BurstEffectObject, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}