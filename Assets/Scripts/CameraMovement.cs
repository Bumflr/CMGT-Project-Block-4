using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float zoom = 30f;

    // Update is called once per frame
    void Update()
    {
        float zoomChangeAmount = 80f;

        if (Input.mouseScrollDelta.y > 0)
        {
            zoom -= zoomChangeAmount * Time.deltaTime * 10f;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            zoom += zoomChangeAmount * Time.deltaTime * 10f; 
        }
        zoom = Mathf.Clamp(zoom, 20f, 40f);

        this.transform.position = new Vector3(zoom, transform.position.y, transform.position.z);
    }
}
