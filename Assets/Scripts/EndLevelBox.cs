using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevelBox : MonoBehaviour
{
    [SerializeField] private Text coinText;

    void Start()
    {
        coinText.text = "x " + GameManager.Instance.currentLevel.prize;
        GameManager.Instance.player.lastLevel++;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
