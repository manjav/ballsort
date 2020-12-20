using System.Collections;
using UnityEngine;

public class GlassesManager : MonoBehaviour
{
    [SerializeField] private Vector2 offset, gap;
    [SerializeField] private Glass glassTemplate;
    [SerializeField] private LevelUI levelUI;
    [SerializeField] private EndLevelBox endLevelBox;
    [HideInInspector] public int tempGlassNumber;
    [HideInInspector] public GameObject tempLastGlass;
    [HideInInspector] public int fullGlassesCount;
    [HideInInspector] public Ball.Type tempBallType;
    [HideInInspector] public int tempLastBallPos;

    private void Start()
    {
        GameManager.Instance.LoadLevel();
        levelUI.Refresh();
        var glassCount = GameManager.Instance.currentLevel.glassCount;

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

        for (int i = 0; i < glassCount; i++)
        {
            float row = Mathf.Floor(i / numCols);
            var col = i % numCols;

            float alignPadding = 0;
            if (row == numLines) //padding: row(2).halign(center)
                alignPadding = padding;

            //Debug.Log(i + "  Row: " + row + "  Col: " + col);
            var glassPos = new Vector3(alignPadding + col * gap.x + offset.x, row * gap.y + offset.y, -1);
            Instantiate<Glass>(glassTemplate, glassPos, Quaternion.identity).Init(this, i, GameManager.Instance.currentLevel.glasses[i]);

        }
        #endregion
    }

    public IEnumerator CheckGlassesFully()
    {
        var count = GameManager.Instance.currentLevel.glassCount;
        if ((count == 3 && fullGlassesCount == 2) || (count > 3 && fullGlassesCount == count - 2))
        {
            yield return new WaitForSeconds(1.5f);
            FindObjectOfType<AudioManager>().Play(Audio.Clip.Win);
            endLevelBox.gameObject.SetActive(true);
            endLevelBox.GetComponent<Animator>().SetBool("Open", true);
            GameManager.Instance.gameEnd = true;
        }
    }
}