using UnityEngine;
using System;

public class SpriteButton : MonoBehaviour
{
    [SerializeField] public event Action onClick;

    public Vector2 press = new Vector2(.1f, .1f);
    Vector2 scale = new Vector2(1, 1);

    void Update()
    {
        scale.x += (1 - scale.x) / 5;
        scale.y += (1 - scale.y) / 5;
        transform.localScale = new Vector2(scale.x, scale.y);
    }

    void OnMouseDown()
    {
        scale.x -= press.x;
        scale.y -= press.y;
        FindObjectOfType<AudioManager>().Play(Audio.Clip.Click, 1, 0);
        onClick?.Invoke();
    }
}