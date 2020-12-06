using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassesManager : MonoBehaviour
{ 
    public int glassCount;
    public Vector2 offset, gap;

    public GameObject glass;
    public List<GameObject> Glasses = new List<GameObject>();
    public int tempGlassNumber;
    public GameObject tempLastGlass;

    public int[] ballColor;
    public Ball.BallType tempBallType;
    public int tempLastBallPos;


    private void Start()
    {
        ballColor[0] = 1;
        ballColor[1] = 1;
        ballColor[2] = 2;
        ballColor[3] = 2;
        ballColor[4] = 1;
        ballColor[5] = 1;
        ballColor[6] = 2;
        ballColor[7] = 2;


        #region Creating, Sorting and Fix Position of Glasses
        float numCols = glassCount;
        if (glassCount > 5) numCols = Mathf.Floor((glassCount / 2) + (glassCount % 2));
        print(numCols);

        //offset.x = -(numCols - 1); // halign(center) if offset.x = 2
        offset.x = -((numCols/2) - .5f); // halign(center) if offset = 1

        var padding = (numCols - glassCount % numCols) * .5f;
        var numLines = Mathf.Floor(glassCount / numCols);
        if (glassCount > 5) offset.y = 1.4f;

        // Set Gap if offset.x = 2
        //offset.x += ((numCols / 10) + .5f)+ 2.4f;
        //gap.x -= (numCols / 10) + .5f;

        for (int i = 0; i < glassCount; i++)
        {
            float row = Mathf.Floor(i / numCols);
            var col = i % numCols;

            float alignPadding = 0;
            if (row == numLines) //padding: row(2).halign(center)
                alignPadding = padding;

            Debug.Log(i + "  Row: " + row + "  Col: " + col);

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
        for (int i = 0; i < glassCount; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Ball.BallType tempValue = (Ball.BallType)ballColor[ballIndex];
                Glasses[i].transform.GetChild(j).GetComponent<Ball>().ballType = tempValue;
                ballIndex++;
            }
        }
    }
}