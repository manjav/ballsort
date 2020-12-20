using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text levelText;

    internal void Refresh()
    {
        levelText.text = "Level " + (GameManager.Instance.currentLevel.index + 1).ToString();
    }
}
