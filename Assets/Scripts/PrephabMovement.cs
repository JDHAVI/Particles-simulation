using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrephabMovement : MonoBehaviour
{
    bool draggable = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (draggable)
        {
            //gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseDown()
    {
        draggable = true;
    }

    private void OnMouseUp()
    {
        draggable = false; 
    }
}
