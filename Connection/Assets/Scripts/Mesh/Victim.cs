using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victim : MonoBehaviour {

    public Material CapMaterial;


    private void Start()
    {
        if (this.CapMaterial) this.CapMaterial = this.GetComponent<MeshRenderer>().material;    
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject[] pieces;
        pieces = BLINDED_AM_ME.MeshCut.Cut(this.gameObject, other.transform.position, other.transform.right, this.CapMaterial);
        
        foreach (GameObject obj in pieces)
        {
            if (!obj.GetComponent<Victim>())
            {
                obj.AddComponent<Victim>();
                obj.GetComponent<Victim>().CapMaterial = this.CapMaterial;
            }
        }


        if (!pieces[1].GetComponent<Rigidbody>())
            pieces[1].AddComponent<Rigidbody>();

    }
}