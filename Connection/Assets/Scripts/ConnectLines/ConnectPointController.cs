using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public class ConnectPointController : MonoBehaviour {

    public GameObject BurstEffectObject;

    [System.NonSerialized]
    public bool IsConnected;

    private Animator animator;

    private void Start()
    {
        this.IsConnected = false;
        this.animator = this.GetComponent<Animator>();
    }


    virtual public void Connected()
    {
        if (this.IsConnected) return;
        this.IsConnected = true;
    }

    /// <summary>
    /// コネクトが確立された後に呼ばれる
    /// </summary>
    virtual public void Burst()
    {
        Instantiate(this.BurstEffectObject, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }


    private void Update()
    {
        this.animator.SetBool("IsConnected", this.IsConnected);   
    }
}