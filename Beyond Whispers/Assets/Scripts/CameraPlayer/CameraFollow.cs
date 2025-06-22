using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    public float smoothSpeed = 0.05f;
    public Vector3 offset;

    public Transform boundaryObject;

    private float camHalfHeight;
    private float camHalfWidth;

    private Vector2 minBounds;
    private Vector2 maxBounds;

    void Start()
    {
        Camera cam = Camera.main;
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = camHalfHeight * cam.aspect;

        if (boundaryObject != null)
        {
            Vector3 boundsCenter = boundaryObject.position;
            Vector3 boundsSize = boundaryObject.localScale;

            minBounds = boundsCenter - boundsSize / 2f;
            maxBounds = boundsCenter + boundsSize / 2f;
        }
        else
        {
            Debug.LogError("Boundary Object (Grass) не задан!");
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x + camHalfWidth, maxBounds.x - camHalfWidth);
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y + camHalfHeight, maxBounds.y - camHalfHeight);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
