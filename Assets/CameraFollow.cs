using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0,1,-10);

    public Vector2 minBound;
    public Vector2 maxBound;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;

            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBound.x, maxBound.x);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBound.y, maxBound.y);

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}