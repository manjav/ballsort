using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int level = 1;
    public Text levelText;

    private void Start()
    {
        levelText.text = "level " + level.ToString();
    }
}
