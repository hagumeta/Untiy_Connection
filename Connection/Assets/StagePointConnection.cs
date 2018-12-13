using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using ListObj = System.Collections.Generic.Queue<UnityEngine.Transform>;

public class StagePointConnection : MonoBehaviour {

    [System.NonSerialized]
    public ListObj connectPoints;


    public void ListAdd(Transform addPoint)
    {
        //同じものが既に入っていたらその時点までを全て除去する
        if (connectPoints.Contains(addPoint))
        {
            foreach (var obj in connectPoints)
            {
                if (obj == addPoint)
                {
                    break;
                }
                else
                {
                    connectPoints.Dequeue();
                }
            }
        }
        else
        {
            //入ってなかったら追加する
            connectPoints.Enqueue(addPoint);
        }
    }


    /// <summary>
    /// 初期化する
    /// </summary>
    public void ListReset()
    {
        this.connectPoints = new ListObj();
    }


    /// <summary>
    /// 
    /// </summary>


	void Start () {
	    	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
