using UnityEngine;
using UnityEngine.UI;

public class EndLevelBox : MonoBehaviour
{
    [SerializeField] private Text coinText;

    void Start()
    {
        coinText.text = "x " + GameManager.Instance.currentLevel.prize;

        GameManager.Instance.player.lastLevel++;
        GameManager.Instance.ShowLevel();
    }
}
