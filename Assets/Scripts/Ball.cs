using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public enum BallType {clear, blue, red, green, yellow};
    public BallType ballType;
    Color tempColor;
    public Sprite[] imageIndex;

    public GameObject glassesManager;
    public float Y, PosY;

    private void Start()
    {
        tempColor = GetComponent<SpriteRenderer>().color;
        glassesManager = GameObject.Find("GlassesManager");
    }

    void Update()
    {
        //if (gameObject.name == "TempBall")
        {
            //tempColor.a += (1 - tempColor.a) / 5;
            if (ballType == BallType.blue) GetComponent<SpriteRenderer>().sprite = imageIndex[0];
            if (ballType == BallType.red) GetComponent<SpriteRenderer>().sprite = imageIndex[1];
            if (ballType == BallType.green) GetComponent<SpriteRenderer>().sprite = imageIndex[2];
            if (ballType == BallType.yellow) GetComponent<SpriteRenderer>().sprite = imageIndex[3];
        }
        //else
        {
            //tempColor.a = (0 - tempColor.a) / 2;
        }
        GetComponent<SpriteRenderer>().color = tempColor;

        if (gameObject.name == "TempBall")
        {
            PosY += (Y - PosY) / 5;
            transform.position = new Vector3(transform.position.x, PosY);
        }
     }

}