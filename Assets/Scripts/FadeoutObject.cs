using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FadeoutObject : MonoBehaviour {

    public float lifetime = 5.0f;
    private SpriteRenderer sprite;

    private float startTime;
    private float startingAlpha;

    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
        startTime = Time.time;
        startingAlpha = sprite.color.a;
    }

	void Update () {
        if (Time.time - startTime >= lifetime) {
            Destroy(this.gameObject);
        }

        Color col = sprite.color;
        col.a = startingAlpha * ( 1.0f - (Time.time - startTime) / lifetime );
        sprite.color = col;
    }

}
