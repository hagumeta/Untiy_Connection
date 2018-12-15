using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerInputPointer : InputPointer {
    protected Animator animator;


    protected override void MoveTouchPosition()
    {
        base.MoveTouchPosition();
        this.animator.SetBool("IsActive", true);
    }


    protected override void HideSelfPointer()
    {
        this.animator.SetBool("IsActive", false);
    }
}