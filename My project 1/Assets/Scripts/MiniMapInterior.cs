using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MiniMapInterior : MonoBehaviourPunCallbacks
{

    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject camera = other.transform.Find("CameraMiniMap").gameObject;
            Debug.Log(camera);
            camera.GetComponent<Transform>().position = new Vector3(camera
            .transform.position.x, other.GetComponent<Transform>().position.y + 2.3f, camera
            .transform.position.z);
            camera.GetComponent<Camera>().orthographicSize = 5.0f;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject camera = other.transform.Find("CameraMiniMap").gameObject;
            camera.GetComponent<Transform>().position = new Vector3(camera
        .transform.position.x, 255, camera
        .transform.position.z);
            camera.GetComponent<Camera>().orthographicSize = 8.0f;
        }
        
    }
}
