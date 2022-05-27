using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   /* [SerializeField]
    private Transform cam;

    public float speed;
    public float movementTime;
    public Vector3 zoomAmount;

    public Vector3 newPos;
    public Vector3 newZoom;

   //private float zoom = 30f;
   // private Vector3 dragOrigin;

    //public float mapMinX, mapMaxX, mapMinY, mapMaxY;
    // Update is called once per frame

    private void Start()
    {
        newPos = transform.position;
        newZoom = cam.localPosition;
    }

    private void LateUpdate()
    {
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            newZoom -= zoomAmount;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            newZoom += zoomAmount;
        }

        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * movementTime);
        cam.localPosition = Vector3.Lerp(cam.localPosition, newZoom, Time.deltaTime * movementTime);
    }*/

   /* void Updpate()
    {
        float zoomChangeAmount = 80f;

        
        zoom = Mathf.Clamp(zoom, 20f, 40f);

        if (Input.GetMouseButtonDown(0))
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            print("origin " + dragOrigin + " newPosition " + cam.ScreenToWorldPoint(Input.mousePosition) + " =difference" + difference);

            cam.transform.position = new Vector3(zoom, difference.x,difference.y);   
        }

        //this.transform.position = new Vector3(zoom, ori, );
    }*/

  

}
