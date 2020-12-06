using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassFullParticle : MonoBehaviour
{
    Color colorAlpha;

    private void Start()
    {
        colorAlpha = GetComponent<SpriteRenderer>().color;
    }

    private void Update()
    {
        colorAlpha.a -= .02f;
        if (colorAlpha.a < 0) Destroy(gameObject);
        GetComponent<SpriteRenderer>().color = colorAlpha;
        transform.Translate(0, .01f, 0);
    }
}
