using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEffect : MonoBehaviour {

    Animator animator;

    virtual protected void Start () {
        //animatorを取得
        this.animator = this.GetComponent<Animator>();
        if (!this.animator) Destroy(this);
	}

    public void DoLightUpEffect()
    {
        this.animator.SetBool("IsLightUpped", true);
    }
}