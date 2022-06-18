using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenRotation : MonoBehaviour
{
    public GameObject lighting;
    private Vector3 rotation;
    // Update is called once per frame
    void Update()
    {
        rotation.x += 5 * Time.deltaTime;

        lighting.transform.eulerAngles = rotation;

    }
}
