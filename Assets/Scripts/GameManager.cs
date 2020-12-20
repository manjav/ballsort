using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public Level currentLevel;
    static public Player player;
    static public Text levelText;
    static public bool gameEnd;

    private void Start()
    {
        player = new Player();
        gameEnd = false;
    }

    static public void LoadLevel()
    {
        // load xml player.lastLevel
        levelText.text = "level " + currentLevel.index.ToString();
    }
}
