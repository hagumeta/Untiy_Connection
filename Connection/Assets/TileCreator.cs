using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCreator : MonoBehaviour {

    public Vector3Int TileNum;
    public GameObject TileObject;
    public Vector3 TileIntervalDist;


	void Start () {
        int x, y, z;
        for (x = 0; x<TileNum.x; x++)
        {
            for (y = 0; y<TileNum.y; y++)
            {
                for (z = 0; z < TileNum.z; z++)
                {
                    var obj = Instantiate(this.TileObject, this.transform);
                    obj.transform.position = new Vector3(this.TileIntervalDist.x*(x - this.TileNum.x/2), this.TileIntervalDist.y * (y - this.TileNum.y / 2), this.TileIntervalDist.z * (z - this.TileNum.z / 2));
                }
            }
        }
	}
}