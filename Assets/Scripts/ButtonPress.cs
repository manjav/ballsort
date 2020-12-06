using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public Vector2 press = new Vector2(.1f, .1f);
    Vector2 scale = new Vector2(1, 1);

    void OnMouseDown()
    {
        scale.x -= press.x;
        scale.y -= press.y;
    }

    void Update()
    {
        scale.x += (1 - scale.x) / 5;
        scale.y += (1 - scale.y) / 5;
        transform.localScale = new Vector2(scale.x, scale.y);
    }
}