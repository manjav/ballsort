using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
    public SpriteButton resetButton;
    public SpriteButton glassPlusButton;

    private void Start()
    {
        resetButton.onClick += resetButton_clickHandler;
        glassPlusButton.onClick += glassPlusButton_clickHandler;
    }

    public void resetButton_clickHandler()
    {
        SceneManager.LoadScene("Play");
    }

    public void glassPlusButton_clickHandler()
    {
        print("Glass Add");
    }
}