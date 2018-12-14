using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstEffectController : MonoBehaviour {

    public float BurstTime, MaxSize;



    private SpriteRenderer[] sprites;
    void Start()
    {
        this.sprites = this.transform.GetComponentsInChildren<SpriteRenderer>();
        StartCoroutine(this.IEBurstEffect());
    }


    private IEnumerator IEBurstEffect()
    {
        float time = this.BurstTime;
        while (time > 0)
        {
            foreach (SpriteRenderer sprite in this.sprites)
            {
                sprite.color = new Color(sprite.color.a, sprite.color.g, sprite.color.b, time*1.3f/this.BurstTime);
            }
            float size = this.MaxSize * (this.BurstTime - time)/ this.BurstTime;
            this.transform.localScale = new Vector3(size, size, size);

            time -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        Destroy(this.gameObject);
    }
}
