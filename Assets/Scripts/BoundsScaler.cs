using UnityEngine;

public class BoundsScaler : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private EdgeCollider2D edgeCollider;

    private void Start()
    {
        SetColliderToCamera();
    }

    private void SetColliderToCamera()
    {
        // Get the camera view bounds
        float camHeight = mainCamera.orthographicSize * 2f;
        float camWidth = camHeight * mainCamera.aspect;

        Vector2[] points = new Vector2[4];

        points[0] = new Vector2(-camWidth / 2f, -camHeight / 2f); // bottom-left (closing the shape, but still excluding bottom)
        points[1] = new Vector2(-camWidth / 2f, camHeight / 2f);  // top-left
        points[2] = new Vector2(camWidth / 2f, camHeight / 2f);   // top-right
        points[3] = new Vector2(camWidth / 2f, -camHeight / 2f);  // bottom-right

        // Set the points to the edge collider (no loop, just the sides)
        edgeCollider.points = points;
    }
}
