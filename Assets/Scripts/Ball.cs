using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public enum BallType {clear, blue, red, green, yellow, orange, purple, aqua};
    public BallType ballType;
    public Sprite[] imageIndex;

    Color colorAlpha;
    public float Y, PosY, StartPosY;

    private void Start()
    {
        PosY = transform.position.y + StartPosY;
        Y = transform.position.y;
        colorAlpha = GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        if (ballType != BallType.clear) GetComponent<SpriteRenderer>().sprite = imageIndex[(int)ballType - 1];
        else GetComponent<SpriteRenderer>().sprite = null;

        if (ballType != BallType.clear)
        {
            colorAlpha.a += (1 - colorAlpha.a) / 7;
        }
        else if (gameObject.name != "AnimBall0" && gameObject.name != "AnimBall1")
        {
            colorAlpha.a += (-2 - colorAlpha.a) / 7;
        }
        GetComponent<SpriteRenderer>().color = colorAlpha;

        {
            PosY += (Y - PosY) / 5;
            transform.position = new Vector3(transform.position.x, PosY);
        }
     }

}