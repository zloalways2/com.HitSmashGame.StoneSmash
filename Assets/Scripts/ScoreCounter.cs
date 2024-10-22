using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    private int _blocksCount;

    private void Start()
    {
        _blocksCount = FindObjectsOfType<Block>().Length;
    }
    public void RemoveBlock()
    {
        _blocksCount -= 1;

        if (_blocksCount == 0) gameController.Win();
    }
}
