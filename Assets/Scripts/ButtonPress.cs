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




//#region Creating, Sorting and Fix Position of Glasses
//var numCols = 5;
//var padding = (numCols - glassCount % numCols) * .5f;
//var numLines = Mathf.Floor(glassCount / numCols);
//        if (glassCount > 4)
//            offset = new Vector2(offset.x, 1.4f);

//        for (int i = 0; i<glassCount; i++)
//        {
//            float row = Mathf.Floor(i / numCols);
//var col = i % numCols;
////Debug.Log(i+" "+row+" "+col);

//float alignPadding = 0;
//            if (row == numLines)
//                alignPadding = padding;
            
//            var glassPos = new Vector3(alignPadding + col * gap.x + offset.x, row * gap.y + offset.y, -1);
//var g = Instantiate(glass, glassPos, Quaternion.identity);
//g.GetComponent<Glass>().glassesManager = gameObject;
//            g.GetComponent<Glass>().glassNumber = i;
//            Glasses.Add(g);

//            if (i == glassCount-1)
//            {
//                //var glassPlusPos = new Vector3(glassPos.x + .9f, glassPos.y, -1);
//                //Instantiate(glassPlus, glassPlusPos, Quaternion.identity);
//            }
//        }
//        #endregion