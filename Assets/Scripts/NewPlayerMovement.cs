using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewPlayerMovement : MonoBehaviour 
{
    public LayerMask WhatCanBeClickedOn;
    private NavMeshAgent myAgent;
    public RaycastHit hitInfo;

    void Start()
    {
        myAgent = GetComponent <NavMeshAgent>();
        myAgent.updateUpAxis = false;
        //myAgent.updateRotation = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast (myRay, out hitInfo, 100, WhatCanBeClickedOn))
            {
                myAgent.SetDestination(hitInfo.point);
            }
        }
        //myAgent.SetDestination(GameObject.Find("ColliderPlane").GetComponent<DoorTeleporterScript>().currentPosition);

        if (GameObject.Find("ColliderPlane").GetComponent<DoorTeleporterScript>().checker == true)
        {
            myAgent.SetDestination(GameObject.Find("ColliderPlane").GetComponent<DoorTeleporterScript>().currentPosition);
            GameObject.Find("ColliderPlane").GetComponent<DoorTeleporterScript>().checker = false;
        }
    }
}
