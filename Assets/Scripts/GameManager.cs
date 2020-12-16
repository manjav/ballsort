using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public Level currentLevel;
    static public Player player;
    public Text levelText;

    private void Start()
    {
        player = new Player();
    }

    static public void LoadLevel()
    {
        // load xml player.lastLevel
        // levelText.text = "level " + currentLevel.index.ToString();
    }
}
