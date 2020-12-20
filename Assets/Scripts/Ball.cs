using UnityEngine;

public class Ball : MonoBehaviour
{
    public enum Type { clear, blue, red, green, yellow, orange, purple, aqua };
     public Type type;
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
        if (type != Type.clear) GetComponent<SpriteRenderer>().sprite = imageIndex[(int)type - 1];
        else GetComponent<SpriteRenderer>().sprite = null;

        if (type != Type.clear)
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