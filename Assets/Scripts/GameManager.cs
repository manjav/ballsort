using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public Level currentLevel;
    static public Player player;
    static public bool gameEnd;

    void Start()
    {
        player = new Player();
    }

    static public void LoadLevel()
    {
        // load xml player.lastLevel
    }
}
