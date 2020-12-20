using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text levelText;
    void Start()
    {
        levelText.text = "level " + GameManager.Instance.currentLevel.index.ToString();
    }


}
