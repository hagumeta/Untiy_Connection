using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour {

    public GameObject[] StageList;

    private static StageController instance;

    private int nowStageIndex;
    public static int NowStageIndex
    {
        get => instance.nowStageIndex;
        set => instance.nowStageIndex = Mathf.Clamp(value, 0, instance.StageList.Length-1);
    }

    private void Start()
    {
        if (instance.gameObject != null)
        {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }

    }


    public static void CreateNextStage()
    {
        NowStageIndex++;
        instance.CreateNowIndexStage();
    }


    public GameObject CreateNowIndexStage()
    {
        var obj = Instantiate(this.StageList[NowStageIndex], this.transform);
        return obj;
    }


}