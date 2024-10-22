using System.Collections;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private SceneSwitcher sceneSwitcher;

    private void Start()
    {
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(5f);
        sceneSwitcher.SwitchToScene("Menu");
    }
}
