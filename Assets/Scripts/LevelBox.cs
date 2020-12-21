using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelBox : MonoBehaviour
{
    public int levelIndex;
    public Text text;

    void Start()
    {
        text.text = levelIndex.ToString();
    }

    public void selectLevel()
    {
        GameManager.Instance.player.lastLevel = levelIndex-1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameObject.SetActive(false);
    }
}