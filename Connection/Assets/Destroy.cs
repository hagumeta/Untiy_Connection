using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    float Time;

	void Start () {
        Destroy(this.gameObject, this.Time);	
	}
	
}