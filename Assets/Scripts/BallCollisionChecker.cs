using UnityEngine;

public class BallCollisionChecker : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Block block))
        {
            block.TakeDamage();
        }
    }
}
