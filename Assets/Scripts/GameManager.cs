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

    static public void LoadLevel()
    {
        // load xml player.lastLevel
    }
}
