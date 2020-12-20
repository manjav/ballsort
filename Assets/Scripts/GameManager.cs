using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public Level currentLevel;
    public Player player;
    public bool gameEnd;

    void Start()
    {
        player = new Player();
    }

    public void ShowLevel()
    {
        // load xml player.lastLevel
    }
}
