using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEffectRandom : TileEffect {

	override protected void Start () {
        base.Start();
        StartCoroutine(this.IELightUp());
	}


    IEnumerator IELightUp()
    {
        yield return new WaitForSeconds(Random.RandomRange(5f, 100f));
        while (true) {
            yield return new WaitForSeconds(20f);
            this.DoLightUpEffect();
        }
    }
}