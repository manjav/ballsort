using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassesManager : MonoBehaviour
{
    public Level level;
    public Vector2 offset, gap;

    public GameObject glass;
    public List<GameObject> Glasses = new List<GameObject>();
    public int tempGlassNumber;
    public GameObject tempLastGlass;
    public int fullGlassesCount;

    public int[] ballColor;
    public Ball.Type tempBallType;
    public int tempLastBallPos;

    public GameObject gameEndBox;

    private void Start()
    {
        var glassCount = GameManager.Instance.currentLevel.glassCount;
        // ballColor => GameManager.currentLevel.glasses;
        // Reterive third ball of second glass => GameManager.currentLevel.glasses[1][2] = Ball.BallType.blue;

        //ballColor = new int[level.glassCount * 4];
        //ballColor[0] = 1;
        //ballColor[1] = 1;
        //ballColor[2] = 2;
        //ballColor[3] = 2;
        //ballColor[4] = 1;
        //ballColor[5] = 1;
        //ballColor[6] = 2;
        //ballColor[7] = 2;

        #region Creating, Sorting and Fix Position of Glasses
        float numCols = glassCount;
        if (glassCount > 5) numCols = Mathf.Floor((glassCount / 2) + (glassCount % 2));

        //offset.x = -(numCols - 1); // halign(center) if offset.x = 2
        offset.x = -((numCols / 2) - .5f); // halign(center) if offset = 1

        var padding = (numCols - glassCount % numCols) * .5f;
        var numLines = Mathf.Floor(glassCount / numCols);
        if (glassCount > 5) offset.y = 1.4f;

        // Set Gap if offset.x = 2
        //offset.x += ((numCols / 10) + .5f)+ 2.4f;
        //gap.x -= (numCols / 10) + .5f;

        for (int i = 0; i < level.glassCount; i++)
        {
            float row = Mathf.Floor(i / numCols);
            var col = i % numCols;

            float alignPadding = 0;
            if (row == numLines) //padding: row(2).halign(center)
                alignPadding = padding;

            //Debug.Log(i + "  Row: " + row + "  Col: " + col);

            var glassPos = new Vector3(alignPadding + col * gap.x + offset.x, row * gap.y + offset.y, -1);
            var g = Instantiate(glass, glassPos, Quaternion.identity);
            g.GetComponent<Glass>().glassesManager = gameObject;
            g.GetComponent<Glass>().glassNumber = i;
            Glasses.Add(g);
        }
        #endregion
        InstallGlasses();
    }

    public void InstallGlasses()
    {
        var ballIndex = 0;
        for (int i = 0; i < level.glassCount; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                //Ball.BallType tempValue = (Ball.BallType)ballColor[ballIndex];
                //Glasses[i].transform.GetChild(j).GetComponent<Ball>().ballType = tempValue;
                //ballIndex++;

                // Glasses[i].transform.GetChild(j).GetComponent<Ball>().ballType = level.glasses[i][j];
            }
        }
    }

    public IEnumerator CheckGlassesFully()
    {
        if ((level.glassCount == 3 && fullGlassesCount == 2) || (level.glassCount > 3 && fullGlassesCount == level.glassCount - 2))
        {
            yield return new WaitForSeconds(1.5f);
            FindObjectOfType<AudioManager>().Play(Audio.Clip.Win);
            gameEndBox.SetActive(true);
            gameEndBox.GetComponent<Animator>().SetBool("Open", true);
            GameManager.Instance.gameEnd = true;
        }
    }
}