using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportacion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){   //input para teletransportarse (0 por el boton del mouse)
            gameObject.transform.position = new Vector3(2f,0f,0f); //para el jugador
            Debug.Log("asdasd");
        }
    }
}
