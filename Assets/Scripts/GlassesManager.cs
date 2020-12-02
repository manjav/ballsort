using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassesManager : MonoBehaviour
{ 
    public int glassCount;
    public GameObject glass;
    public List<GameObject> Glasses = new List<GameObject>();
    public int[] ballColor;
    public Ball.BallType tempBallType;
    public int tempGlassNumber;
    public Vector2 offset = new Vector2(-1.5f, 1);
    public Vector2 gap = new Vector2(2, 2);

    private void Start()
    {
        #region old
        //ballColor[0] = 1;
        //ballColor[1] = Color.red;
        //ballColor[2] = Color.yellow;
        //ballColor[3] = Color.cyan;
        //ballColor[4] = Color.gray;
        //ballColor[5] = Color.yellow;
        //ballColor[6] = Color.cyan;
        #endregion
        #region Creating, Sorting and Fix Position of Glasses
        var numCols = 4;
        var padding = (numCols - glassCount % numCols)*.5f;
        var numLines = Mathf.Floor(glassCount / numCols);

        for (int i = 0; i < glassCount; i++)
        {
            float row = Mathf.Floor(i / numCols);
            var col = i % numCols;
            //Debug.Log(i+" "+row+" "+col);

            float alignPadding = 0;
            if (row == numLines)
                alignPadding = padding;

            var glassPos = new Vector3(alignPadding + col *gap.x + offset.x, row * gap.y + offset.y, -1);
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
                //Glasses[i].transform.GetChild(j).GetComponent<Ball>().ballType = ballColor[ballIndex];
                ballIndex++;
            }
        }
    }
    
}