using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private SceneSwitcher sceneSwitcher;

    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject failPanel;

    [SerializeField] private Timer timer;

    [SerializeField] private TextMeshProUGUI levelIndexText;
    [SerializeField] private int levelIndex;

    private void Awake()
    {
        Physics2D.simulationMode = SimulationMode2D.FixedUpdate;
    }

    private void Start()
    {
        levelIndexText.text = "Lvl " + levelIndex;
    }

    public void Pause()
    {
        Physics2D.simulationMode = SimulationMode2D.Script;
        timer.IsEnabled = false;
    }

    public void Unpause()
    {
        Physics2D.simulationMode = SimulationMode2D.FixedUpdate;
        timer.IsEnabled = true;
    }

    public void Win()
    {
        Physics2D.simulationMode = SimulationMode2D.Script;
        PlayerPrefs.SetInt("Level" + (levelIndex + 1), 1);
        gamePanel.SetActive(false);
        winPanel.SetActive(true);
        timer.Disable();
    }

    public void Fail()
    {
        Physics2D.simulationMode = SimulationMode2D.Script;
        gamePanel.SetActive(false);
        failPanel.SetActive(true);
        timer.Disable();
    }

    public void Restart()
    {
        sceneSwitcher.SwitchToScene("Level" + levelIndex);
    }

    public void NextLevel()
    {
        sceneSwitcher.SwitchToScene("Level" + (levelIndex + 1));
    }

    public void Menu()
    {
        sceneSwitcher.SwitchToScene("Menu");
    }
}
