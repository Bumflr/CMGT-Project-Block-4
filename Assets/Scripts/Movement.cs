using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public Camera cam;
    //public float zOffset;
    //public float yOffset;

    public NavMeshAgent Agent;

    //private bool drag;

    //Vector3 proportionalPosition;
    //Vector3 origin;
 
    void Upadte ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //ray variable to be used for agent move position
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //If the ray hits
            if (Physics.Raycast(ray, out hit))
            {
                Agent.SetDestination(hit.point);
            }
        }
    }
    
    
    
    /*private void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 ViewportPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            if (drag == false)
            {
                drag = true;
                origin = ViewportPosition;
            }

            proportionalPosition = new Vector3(33.1f, ViewportPosition.y * 20 + yOffset, ViewportPosition.x * 20 + zOffset);

        }
        else
        {
            drag = false;
        }

        if (drag)
        {
            cam.transform.position = proportionalPosition - origin;
        }
    }*/


    /*private void FixedUpdate()
    {
       
        if (Input.GetKey(KeyCode.W))
        {
            cam.gameObject.transform.Translate(new Vector3(0, 2, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            cam.gameObject.transform.Translate(new Vector3(0, -2, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            cam.gameObject.transform.Translate(new Vector3(-2, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            cam.gameObject.transform.Translate(new Vector3(2, 0, 0));
        }



        cam.gameObject.transform.position = new Vector3(cam.gameObject.transform.position.x, Mathf.Clamp(cam.gameObject.transform.position.y, minY, maxY), Mathf.Clamp(cam.gameObject.transform.position.z, minZ, maxZ));


    }*/
}
