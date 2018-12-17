using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageUnitController : MonoBehaviour {

    private static StageUnitController instance;

    private void Start()
    {
        if (instance != null) {
            Destroy(instance.gameObject);
        }
        instance = this;
    }


    public static void StageComplete()
    {
        StageController.CreateNextStage();
        Destroy(instance.gameObject);
    }
}