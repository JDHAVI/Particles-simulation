using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float panSpeed = 4f;
    public float zoomSpeed = 2f;
    public float speedOffset = 2f;

    float minSpeed = 1;
    float maxSpeed = 6;

    float minZoom = 1;
    float maxZoom = 300;

    void Update()
    {
        CameraMovement();
        CameraZoom();
    }

    void CameraZoom()
    {
        float delta = Input.mouseScrollDelta.y;
        if (delta != 0)
        {
            float currentSize = Camera.main.orthographicSize;
            currentSize = currentSize - zoomSpeed * delta;
            currentSize = Mathf.Clamp(currentSize, minZoom, maxZoom);
            Camera.main.orthographicSize = currentSize; 
        }
    }

    void CameraMovement()
    {
        float delta = Input.mouseScrollDelta.y;
        if (Input.GetMouseButton(2))
        {
            if (delta <= -1)
            {
                panSpeed -= speedOffset;
            }

            float moveX = -Input.GetAxis("Mouse X") * panSpeed;
            float moveY = -Input.GetAxis("Mouse Y") * panSpeed;

            transform.Translate(new Vector3(moveX, moveY, 0));
        }
    }
}