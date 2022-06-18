using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleporterScript : MonoBehaviour
{

    public Transform player;
    public Transform reciever;

    private bool playerIsOverlapping = false;
    void Update()
    {
        Debug.Log(playerIsOverlapping);
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            //If this is true: The player is passed through the portal
            if (dotProduct < 0f)
            {
                //Teleport the palyer
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffset;

                playerIsOverlapping = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            playerIsOverlapping = false;
        }
    }
}
