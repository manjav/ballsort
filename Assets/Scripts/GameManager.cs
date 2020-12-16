using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public Level level;
    public Text levelText;

    private void Start()
    {
        levelText.text = "level " + level.index.ToString();
    }
}
