using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    [SerializeField] private ScoreCounter scoreCounter;

    [SerializeField] private Animation blockHitAnimation;

    [SerializeField] private GameObject particlesPrefab;
    [SerializeField] private TextMeshPro blockHealthText;
    [SerializeField] private int health;

    private Transform _thisObjectTransform;

    private void Awake()
    {
        _thisObjectTransform = transform;
    }

    private void Start()
    {
        blockHealthText.text = health.ToString();
    }

    public void TakeDamage()
    {
        health -= PlayerPrefs.GetInt("Multiplier", 1);
        blockHealthText.text = health.ToString();

        blockHitAnimation.Stop();
        blockHitAnimation.Play();

        if (health <= 0)
        {
            scoreCounter.RemoveBlock();

            Instantiate(particlesPrefab, _thisObjectTransform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
