using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float panSpeed = 0.5f; 

    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            float moveX = -Input.GetAxis("Mouse X") * panSpeed;
            float moveY = -Input.GetAxis("Mouse Y") * panSpeed;

            transform.Translate(new Vector3(moveX, moveY, 0));
        }
    }
}