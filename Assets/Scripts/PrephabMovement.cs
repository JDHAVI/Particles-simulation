using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class PrephabMovement : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    private void Start()
    {

    }

    void OnMouseDown()
    {
        isDragging = true;

        // положение мыши в мировых координатах
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;

        // чтобы объект не "скакал" под курсор
        offset = transform.position - mousePos;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = transform.position.z;

            transform.position = mousePos + offset;
        }
    }

}
