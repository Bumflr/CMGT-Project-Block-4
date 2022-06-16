using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewPlayerMovement : MonoBehaviour 
{
    public LayerMask WhatCanBeClickedOn;

    private NavMeshAgent myAgent;
    void Start()
    {
        myAgent = GetComponent <NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast (myRay, out hitInfo, 100, WhatCanBeClickedOn))
            {
                myAgent.SetDestination(hitInfo.point);
            }
        }
    }
}
