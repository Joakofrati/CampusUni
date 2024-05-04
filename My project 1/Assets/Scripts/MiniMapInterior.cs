using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapInterior : MonoBehaviour
{
    public GameObject camera;
    public GameObject player;

    void Start()
    {
        
    }

    void OnTriggerEnter()
    {
        camera.GetComponent<Transform>().position = new Vector3(camera
        .transform.position.x,player.GetComponent<Transform>().position.y + 2.3f, camera
        .transform.position.z);
        camera.GetComponent<Camera>().orthographicSize = 5.0f;
    }

    void OnTriggerExit()
    {
        camera.GetComponent<Transform>().position = new Vector3(camera
        .transform.position.x,255, camera
        .transform.position.z);
        camera.GetComponent<Camera>().orthographicSize = 8.0f;
    }
}
