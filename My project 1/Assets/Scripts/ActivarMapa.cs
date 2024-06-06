using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivarMapa : MonoBehaviour
{
    private bool activeCanvasMiniMap;
    public GameObject CanvasMiniMap;
    public GameObject Player;
    public GameObject mensaje;
    public GameObject MiniMap;
    public GameObject ImagenMapa;

    void Start()
    {   
        ImagenMapa.SetActive(false);
        activeCanvasMiniMap = false;
        CanvasMiniMap.SetActive(false);
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.M)) && (!activeCanvasMiniMap))
        { 
            mensaje.SetActive(false);
            ImagenMapa.SetActive(true);
            activeCanvasMiniMap = true;
            CanvasMiniMap.SetActive(true);
            MiniMap.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Player.GetComponent<PlayerMove>().enabled = false;
            Cursor.visible = true;

        } else if (Input.GetKeyDown(KeyCode.M) && activeCanvasMiniMap)
        {
            mensaje.SetActive(false);
            activeCanvasMiniMap = false;
            ImagenMapa.SetActive(false);
            CanvasMiniMap.SetActive(false);
            MiniMap.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Player.GetComponent<PlayerMove>().enabled = true;
            Cursor.visible = false;
            
           

        }
    }

    
}