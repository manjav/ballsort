using UnityEngine;
using UnityEngine.UI;

public class EndLevelBox : MonoBehaviour
{
    [SerializeField] private Text coinText;

    void Start()
    {
        coinText.text = "x " + GameManager.currentLevel.prize;

        GameManager.player.lastLevel++;
        GameManager.LoadLevel();
    }
}
