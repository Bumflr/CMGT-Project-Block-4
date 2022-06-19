using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorTeleporterScript : MonoBehaviour
{

    public Transform player;
    public Transform reciever;
    public NavMeshAgent PlayerAgent;
    public Vector3 dest = new Vector3();
    public Vector3 currentPosition;
    public bool checker = false;


    //private bool playerIsOverlapping = false;
    void Update()
    {
        /*Debug.Log(playerIsOverlapping);
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            //If this is true: The player is passed through the portal
            if (dotProduct < 0f)
            {
                //Teleport the palyer
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                player.Rotate(Vector3.up, rotationDiff);
                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffset;

                playerIsOverlapping = false;
            }
        }*/
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerAgent.Warp(dest);
            currentPosition = GameObject.Find("Player").GetComponent<NewPlayerMovement>().hitInfo.point;
            checker = true;
        }
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }*/
}
