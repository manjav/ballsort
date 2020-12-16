using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddNewGlass()
    {
        print("Glass Add");
    }

    public void LoadNextLevel()
    {
        ReloadLevel();
    }

    public void ShowLevels()
    {
        print("ShowLevels");
    }
}