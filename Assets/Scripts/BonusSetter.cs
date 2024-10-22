using UnityEngine;
using UnityEngine.UI;

public class BonusSetter : MonoBehaviour
{
    [SerializeField] private Button _2xOnButton;
    [SerializeField] private Button _3xOnButton;
    [SerializeField] private Button _10xOnButton;

    private void Start()
    {
        int multiplier = PlayerPrefs.GetInt("Multiplier");

        if (multiplier == 2) _2xOnButton.onClick.Invoke();
        else if (multiplier == 3) _3xOnButton.onClick.Invoke();
        else if (multiplier == 10) _10xOnButton.onClick.Invoke();
    }

    public void SetMultiplier(int multiplier)
    {
        PlayerPrefs.SetInt("Multiplier", multiplier);
    }
}
