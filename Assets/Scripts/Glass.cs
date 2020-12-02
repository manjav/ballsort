using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public List<GameObject> balls = new List<GameObject>();
    public GameObject glassesManager;
    public int glassNumber;
    public int tempLastBallPos;
    public GameObject tempBall;
    //public GameObject templastGlass;

    private void Start()
    {
        tempBall = GameObject.Find("TempBall");
    }

    void OnMouseDown()
    {
        if (glassesManager.GetComponent<GlassesManager>().tempBallType == Ball.BallType.clear)
        {
            SendToPortal();
        }
        else
        {
            if (glassesManager.GetComponent<GlassesManager>().tempGlassNumber == glassNumber)
            {
                BackToLastGlass();
            }
            else
            {
                PutToNewGlass();
            }
        }
    }

    public void SendToPortal()
    {
        for (int i = 3; i >= 0; i--) // Move ball to Portal
        {
            if (transform.GetChild(i).GetComponent<Ball>().ballType != Ball.BallType.clear)
            {
                glassesManager.GetComponent<GlassesManager>().tempBallType = transform.GetChild(i).GetComponent<Ball>().ballType;
                transform.GetChild(i).GetComponent<Ball>().ballType = Ball.BallType.clear;
                tempLastBallPos = i;
                //templastGlass = transform.gameObject;
                glassesManager.GetComponent<GlassesManager>().tempGlassNumber = glassNumber;

                //transform.GetChild(i).GetComponent<BallCreator>().b.transform.position = new Vector2(transform.position.x, transform.GetChild(i).position.y);
                //transform.GetChild(i).GetComponent<BallCreator>().b.GetComponent<Ball>().ballType = glassesManager.GetComponent<GlassesManager>().tempBallType;
                //transform.GetChild(i).GetComponent<BallCreator>().b.GetComponent<Ball>().PosY = transform.GetChild(i).position.y;
                //transform.GetChild(i).GetComponent<BallCreator>().b.GetComponent<Ball>().Y = transform.position.y + 1.5f;
                tempBall.transform.position = new Vector2(transform.position.x, transform.GetChild(i).position.y);
                tempBall.GetComponent<Ball>().ballType = glassesManager.GetComponent<GlassesManager>().tempBallType;
                tempBall.GetComponent<Ball>().PosY = transform.GetChild(i).position.y;
                tempBall.GetComponent<Ball>().Y = transform.position.y + 1.5f;
                return;
            }

        }
    }

    public void BackToLastGlass()
    {
        transform.GetChild(tempLastBallPos).GetComponent<Ball>().ballType = glassesManager.GetComponent<GlassesManager>().tempBallType;
        glassesManager.GetComponent<GlassesManager>().tempBallType = Ball.BallType.clear;

        tempBall.GetComponent<Ball>().ballType = transform.GetChild(tempLastBallPos).GetComponent<Ball>().ballType;
        tempBall.GetComponent<Ball>().Y = transform.GetChild(tempLastBallPos).position.y;
    }

    public void PutToNewGlass()
    {
        if (transform.GetChild(0).GetComponent<Ball>().ballType == Ball.BallType.clear) // Check glass free and put to glass spot(0)
        {
            transform.GetChild(0).GetComponent<Ball>().ballType = glassesManager.GetComponent<GlassesManager>().tempBallType;
            glassesManager.GetComponent<GlassesManager>().tempBallType = Ball.BallType.clear;

            tempBall.GetComponent<Ball>().ballType = transform.GetChild(0).GetComponent<Ball>().ballType;
            //tempBall.transform.position = new Vector3(transform.position.x, tempBall.transform.position.y);
            //tempBall.GetComponent<Ball>().Y = transform.GetChild(0).position.y;
        }
        else
        {
            for (int i = 0; i <= 3; i++) // Check color and spots free and put to glass
            {
                if ((transform.GetChild(i).GetComponent<Ball>().ballType == Ball.BallType.clear)
                    && (transform.GetChild(i - 1).GetComponent<Ball>().ballType == glassesManager.GetComponent<GlassesManager>().tempBallType))
                {
                    transform.GetChild(i).GetComponent<Ball>().ballType = glassesManager.GetComponent<GlassesManager>().tempBallType;
                    glassesManager.GetComponent<GlassesManager>().tempBallType = Ball.BallType.clear;

                    tempBall.GetComponent<Ball>().ballType = transform.GetChild(i).GetComponent<Ball>().ballType;
                    tempBall.transform.position = new Vector3(transform.position.x, tempBall.transform.position.y);
                    tempBall.GetComponent<Ball>().Y = transform.GetChild(i).position.y;

                    return;
                }
            }
            //for (int i = 3; i >= 0; i--) // Back to last glass
            //{
            //    //if ((transform.GetChild(i).GetComponent<Ball>().ballType != Ball.BallType.clear)
            //    //    && (transform.GetChild(i).GetComponent<Ball>().ballType != glassesManager.GetComponent<GlassesManager>().tempBallType))
            //    //{
            //    //    templastGlass.transform.GetChild(tempLastBallPos).GetComponent<Ball>().ballType = glassesManager.GetComponent<GlassesManager>().tempBallType;
            //    //    glassesManager.GetComponent<GlassesManager>().tempBallType = Ball.BallType.clear;
            //    //    tempBall.GetComponent<Ball>().Y = templastGlass.transform.GetChild(tempLastBallPos).position.y;
            //    //    return;
            //    //}
            //}

        }
    }
}


//    void Update()
//    {
//        //for (int i = 0; i < 3; i++) // Sort balls down
//        //{
//        //    if (transform.GetChild(i).GetComponent<SpriteRenderer>().color == Color.clear)
//        //    {
//        //        transform.GetChild(i).GetComponent<SpriteRenderer>().color = transform.GetChild(i + 1).GetComponent<SpriteRenderer>().color;
//        //        transform.GetChild(i + 1).GetComponent<SpriteRenderer>().color = Color.clear;
//        //    }
//        //}
//    }