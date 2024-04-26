using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{

    PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        playerMove = gameObject.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()    // sin rigidmove (creo)  si no funciona la funcion de abajo
    {
        if (Input.GetMouseButtonDown(0)){   //input para teletransportarse (0 por el boton del mouse)
            StartCoroutine("Teleport");
        }
    }

    IEnumerator Teleport(){
        //Desactivar player movement 
        yield return new WaitForSeconds(0.5f); //tiempo que se desactiva y activa el movimiento
        gameObject.transform.position = new Vector3(2f,0f,0f); //para el jugador
        Debug.Log("asdasd");
        yield return new WaitForSeconds(0.5f); //tiempo que se desactiva y activa el movimiento
        //Activar player movement
    }
    // void Update()
    //{
    //    if (Input.GetMouseButtonDown(0)){   //input para teletransportarse (0 por el boton del mouse)
    //        gameObject.transform.position = new Vector3(2f,0f,0f); //para el jugador
    //        Debug.Log("asdasd");
    //    }
    //}
}
