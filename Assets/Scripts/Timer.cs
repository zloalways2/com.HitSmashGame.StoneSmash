using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI failTimerText, winTimerText;
    [SerializeField] private GameController gameController;

    [SerializeField] private int timeLimit;

    public bool IsEnabled { private get; set; } = true;

    private void Start()
    {
        timerText.text = "Timer: " + timeLimit + " sec";
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        while (true)
        {
            yield return new WaitUntil(() => IsEnabled == true);
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => IsEnabled == true);

            timeLimit -= 1;
            timerText.text = "Timer: " + timeLimit + " sec";

            if (timeLimit == 0)
            {
                gameController.Fail();
            }

            yield return new WaitForEndOfFrame();
        }
    }

    public void Disable()
    {
        failTimerText.text = winTimerText.text = "Timer: " + timeLimit + " sec";
        StopAllCoroutines();
    }
}