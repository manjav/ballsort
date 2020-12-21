using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelBox : MonoBehaviour
{
    public void selectLevel( int levelIndex )
    {
        GameManager.Instance.player.lastLevel = levelIndex;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
