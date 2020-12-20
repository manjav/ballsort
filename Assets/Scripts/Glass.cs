using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public List<GameObject> balls = new List<GameObject>();
    public GameObject glassesManager;
    public int glassNumber;
    public GameObject animBall0, animBall1;
    public bool glassIsFull;

    private void Start()
    {
        animBall0 = GameObject.Find("AnimBall0");
        animBall1 = GameObject.Find("AnimBall1");
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
            if (transform.GetChild(i).GetComponent<Ball>().ballType != Ball.BallType.clear && glassIsFull != true)
            {
                glassesManager.GetComponent<GlassesManager>().tempBallType = transform.GetChild(i).GetComponent<Ball>().ballType;
                transform.GetChild(i).GetComponent<Ball>().ballType = Ball.BallType.clear;
                glassesManager.GetComponent<GlassesManager>().tempLastBallPos = i;
                glassesManager.GetComponent<GlassesManager>().tempLastGlass = transform.gameObject;
                glassesManager.GetComponent<GlassesManager>().tempGlassNumber = glassNumber;

                animBall0.transform.position = new Vector2(transform.position.x, transform.GetChild(i).position.y);
                animBall0.GetComponent<Ball>().ballType = glassesManager.GetComponent<GlassesManager>().tempBallType;
                animBall0.GetComponent<Ball>().PosY = transform.GetChild(i).position.y;
                animBall0.GetComponent<Ball>().Y = transform.position.y + 1.5f;

                CheckGlassFull();

                return;
            }
        }
    }

    public void BackToLastGlass()
    {
        transform.GetChild(glassesManager.GetComponent<GlassesManager>().tempLastBallPos).GetComponent<Ball>().ballType = glassesManager.GetComponent<GlassesManager>().tempBallType;
        glassesManager.GetComponent<GlassesManager>().tempBallType = Ball.BallType.clear;

        animBall0.GetComponent<Ball>().ballType = transform.GetChild(glassesManager.GetComponent<GlassesManager>().tempLastBallPos).GetComponent<Ball>().ballType;
        animBall0.GetComponent<Ball>().Y = transform.GetChild(glassesManager.GetComponent<GlassesManager>().tempLastBallPos).position.y;

        animBall1.GetComponent<Ball>().ballType = Ball.BallType.clear;

        CheckGlassFull();
    }

    public void PutToNewGlass()
    {
        if (transform.GetChild(0).GetComponent<Ball>().ballType == Ball.BallType.clear) // Check glass free and put to glass spot(0)
        {
            transform.GetChild(0).GetComponent<Ball>().ballType = glassesManager.GetComponent<GlassesManager>().tempBallType;
            glassesManager.GetComponent<GlassesManager>().tempBallType = Ball.BallType.clear;

            animBall0.GetComponent<Ball>().ballType = transform.GetChild(0).GetComponent<Ball>().ballType;
            animBall0.transform.position = new Vector3(transform.position.x, animBall0.transform.position.y);
            animBall0.GetComponent<Ball>().PosY = transform.position.y + 1.8f;
            animBall0.GetComponent<Ball>().Y = transform.GetChild(0).position.y;

            animBall1.GetComponent<Ball>().ballType = Ball.BallType.clear;
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

                    animBall0.GetComponent<Ball>().ballType = transform.GetChild(i).GetComponent<Ball>().ballType;
                    animBall0.transform.position = new Vector3(transform.position.x, animBall0.transform.position.y);
                    animBall0.GetComponent<Ball>().PosY = transform.position.y + 1.8f;
                    animBall0.GetComponent<Ball>().Y = transform.GetChild(i).position.y;

                    animBall1.GetComponent<Ball>().ballType = Ball.BallType.clear;

                    CheckGlassFull();

                    return;
                }
            }
            for (int i = 3; i >= 0; i--) // Back to last glass and send new ball to portal.
            {
                if ((transform.GetChild(i).GetComponent<Ball>().ballType != Ball.BallType.clear)
                    && (transform.GetChild(i).GetComponent<Ball>().ballType != glassesManager.GetComponent<GlassesManager>().tempBallType))
                {
                    glassesManager.GetComponent<GlassesManager>().tempLastGlass.transform.GetChild(glassesManager.GetComponent<GlassesManager>().tempLastBallPos).GetComponent<Ball>().ballType = glassesManager.GetComponent<GlassesManager>().tempBallType;
                    glassesManager.GetComponent<GlassesManager>().tempBallType = Ball.BallType.clear;

                    animBall0.GetComponent<Ball>().Y = glassesManager.GetComponent<GlassesManager>().tempLastGlass.transform.GetChild(glassesManager.GetComponent<GlassesManager>().tempLastBallPos).position.y;
                    glassesManager.GetComponent<GlassesManager>().tempLastGlass.GetComponent<Glass>().CheckGlassFull(); //LastGlass.CheckGlassFull

                    animBall1.GetComponent<Ball>().ballType = glassesManager.GetComponent<GlassesManager>().tempLastGlass.transform.GetChild(glassesManager.GetComponent<GlassesManager>().tempLastBallPos).GetComponent<Ball>().ballType;
                    animBall1.GetComponent<Ball>().transform.position = new Vector2(glassesManager.GetComponent<GlassesManager>().tempLastGlass.transform.position.x, glassesManager.GetComponent<GlassesManager>().tempLastGlass.transform.position.y + 1.8f);
                    animBall1.GetComponent<Ball>().PosY = glassesManager.GetComponent<GlassesManager>().tempLastGlass.transform.position.y + 1.8f;
                    animBall1.GetComponent<Ball>().Y = glassesManager.GetComponent<GlassesManager>().tempLastGlass.transform.GetChild(glassesManager.GetComponent<GlassesManager>().tempLastBallPos).transform.position.y;

                    SendToPortal();

                    return;
                }
            }
        }
    }

    public void CheckGlassFull()
    {
        if (transform.GetChild(0).GetComponent<Ball>().ballType != Ball.BallType.clear)
        {
            for (int i = 1; i <= 3; i++)
            {
                if (transform.GetChild(i).GetComponent<Ball>().ballType == transform.GetChild(0).GetComponent<Ball>().ballType)
                {
                    if (transform.GetChild(3).GetComponent<Ball>().ballType == transform.GetChild(0).GetComponent<Ball>().ballType)
                    {
                        glassIsFull = true;
                        transform.GetChild(4).GetComponent<SpriteRenderer>().enabled = true;
                        transform.GetChild(4).GetComponent<Animator>().SetBool("Open", true);
                        FindObjectOfType<AudioManager>().Play(Audio.Clip.GlassFully);
                        StartCoroutine(GlassFullParticle());
                        glassesManager.GetComponent<GlassesManager>().fullGlassesCount += 1;
                        glassesManager.GetComponent<GlassesManager>().StartCoroutine(glassesManager.GetComponent<GlassesManager>().CheckGlassesFully());
                        return;
                    }
                }
                else
                {
                    transform.GetChild(4).GetComponent<SpriteRenderer>().enabled = false;
                    transform.GetChild(4).GetComponent<Animator>().SetBool("Open", false);
                    return;
                }

            }
        }
    }

    public GameObject glassFullParticle;

    public IEnumerator GlassFullParticle()
    {
        while (true && GameManager.Instance.gameEnd == false)
        {
            yield return new WaitForSeconds((float)Random.Range(.001f, .3f));
            var g = Instantiate(glassFullParticle, new Vector2(transform.position.x + Random.Range(-.15f, .15f), transform.position.y + 1.1f), Quaternion.identity);
            g.GetComponent<SpriteRenderer>().sprite = transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
        }
    }
}

//if (doneAnim != null)
//{
//bool isOpen = doneAnim.GetBool("Open");
//doneAnim.SetBool("Open", !isOpen);
//}