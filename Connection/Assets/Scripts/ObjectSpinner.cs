using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpinner : MonoBehaviour {

    public Vector3 SpinSpeed;

	void Update () {
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles + this.SpinSpeed);
	}

}