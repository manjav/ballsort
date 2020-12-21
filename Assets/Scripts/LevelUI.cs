using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text levelText;
    [SerializeField] private GameObject showLevelsBox;


    internal void Refresh()
    {
        levelText.text = "Level " + (GameManager.Instance.currentLevel.index+1).ToString();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowLevelsBox()
    {
        if (showLevelsBox.activeInHierarchy == false)
            showLevelsBox.gameObject.SetActive(true);
        else
            showLevelsBox.gameObject.SetActive(false);
    }
}