using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //Poop
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(0, 0, -12.5f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(0, 0, 12.5f);
        }
    }
}
