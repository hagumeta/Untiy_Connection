using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageUnitController : MonoBehaviour {
    
    public void StageComplete()
    {
        StageController.CreateNextStage();
        Destroy(this);
    }
}