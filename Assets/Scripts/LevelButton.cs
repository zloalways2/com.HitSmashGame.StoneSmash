using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelIndexText;
    [SerializeField] private Button button;
    [SerializeField] private int levelIndex;

    private void Start()
    {
        levelIndexText.text = "Lvl " + levelIndex;
        button.interactable = levelIndex == 1 || PlayerPrefs.GetInt("Level" + levelIndex, 0) == 1;
    }

    public void Play()
    {
        SceneSwitcher.Instance.SwitchToScene("Level" + levelIndex);
    }
}