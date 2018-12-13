using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class InputPointer : MonoBehaviour {

    protected new Rigidbody2D rigidbody;

    protected void Start()
    {
        this.rigidbody = this.GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (InputUtil.IsTouching)
        {
            this.MoveTouchPosition();
        }
        else
        {
            this.HideSelfPointer();
        }
    }


    protected virtual void MoveTouchPosition(){
        this.rigidbody.MovePosition(InputUtil.TouchPositionWorld);
    }
    protected virtual void HideSelfPointer(){}
}


public class InputUtil
{
    public enum Platform
    {
        Mobile, PC, Undefined
    }
    public static Platform GetPlatform()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) {
            // android / IOS
            return Platform.Mobile;
        } else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXPlayer) {
            // Windows / Mac / windowsEditor
            return Platform.PC;
        }
        return Platform.Undefined;
    }

    public static bool IsTouched
    {
        get{
            switch (GetPlatform())
            {
                case Platform.PC:
                    return Input.GetMouseButtonDown(0);
                case Platform.Mobile:
                    Touch touch = Input.GetTouch(0);
                    return touch.phase == TouchPhase.Began;
                default:
                    return false;
            }
        }
    }
    
    public static bool IsTouchReleased
    {
        get
        {
            switch (GetPlatform())
            {
                case Platform.PC:
                    return Input.GetMouseButtonUp(0);
                case Platform.Mobile:
                    Touch touch = Input.GetTouch(0);
                    return touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled;
                default:
                    return false;
            }
        }
    }

    public static bool IsTouching
    {
        get
        {
            switch (GetPlatform())
            {
                case Platform.PC:
                    return Input.GetMouseButton(0);
                case Platform.Mobile:
                    Touch touch = Input.GetTouch(0);
                    return touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary;
                default:
                    return false;

            }
        }
    }


    public static Vector2 TouchPositionScreen
    {
        get
        {
            switch (GetPlatform())
            {
                case Platform.PC:
                    return Input.mousePosition;
                case Platform.Mobile:
                    Touch touch = Input.GetTouch(0);
                    return touch.position;
                default:
                    return Vector2.zero;

            }
        }
    }

    public static Vector2 TouchPositionWorld
    {
        get
        {
            Camera camera = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<Camera>();
            return camera.ScreenToWorldPoint(TouchPositionScreen);
        }
    }
}