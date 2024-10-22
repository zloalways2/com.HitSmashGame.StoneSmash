using UnityEngine;
using UnityEngine.EventSystems;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    [SerializeField] private GameObject ballTrajectoryObject;
    [SerializeField] private Transform ballTrajectoryTransform;
    [SerializeField] private Rigidbody2D ballRb;

    [SerializeField] private float velocityMutliplier;

    private void OnEnable()
    {
        ballTrajectoryObject.SetActive(true);
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject(0)) return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Began)
            {
                Vector2 worldPos = mainCamera.ScreenToWorldPoint(touch.position);
                Vector2 direction = worldPos - (Vector2)ballTrajectoryTransform.position;

                ballTrajectoryTransform.up = direction;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                ballRb.velocity = ballTrajectoryTransform.up * velocityMutliplier * PlayerPrefs.GetInt("Multiplier", 1) / 2;
                ballTrajectoryObject.SetActive(false);
                enabled = false;
            }
        }
    }
}
