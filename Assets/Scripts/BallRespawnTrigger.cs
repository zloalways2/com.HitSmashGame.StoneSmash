using UnityEngine;
using DG.Tweening;

public class BallRespawnTrigger : MonoBehaviour
{
    [SerializeField] private BallLauncher ballLauncher;

    [SerializeField] private SpriteRenderer ballSpriteRenderer;
    [SerializeField] private Rigidbody2D ballRb;
    [SerializeField] private Transform ballTransform;
    [SerializeField] private Transform ballSpawnpoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BallCollisionChecker _))
        {
            RespawnBall();
        }
    }

    private void RespawnBall()
    {
        ballRb.velocity = Vector2.zero;
        ballRb.simulated = false;

        ballSpriteRenderer.color = new Color(1, 1, 1, 0);
        ballTransform.position = ballSpawnpoint.position;

        ballSpriteRenderer.DOFade(1f, 0.5f).OnComplete(() =>
        {
            ballLauncher.enabled = true;
            ballRb.simulated = true;
        });
    }
}
