using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivarMapa : MonoBehaviour
{
    private bool activeCanvasMiniMap;
    public GameObject CanvasMiniMap;
    public GameObject camaraMapa;
    public GameObject Player;
    private GameObject MiniMap;

    void Start()
    {
        activeCanvasMiniMap = false;
        CanvasMiniMap.SetActive(false);
        Player = GameObject.FindGameObjectWithTag("Player");
        MiniMap = Player.transform.Find("MiniMapPlayer").gameObject;
    }

    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.M)) && (!activeCanvasMiniMap))
        {
            camaraMapa.active = true;
            activeCanvasMiniMap = true;
            CanvasMiniMap.SetActive(true);
            MiniMap.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Player.GetComponent<PlayerMove>().canMoveToggle(false);
            Cursor.visible = true;

        }
        else if (Input.GetKeyDown(KeyCode.M) && activeCanvasMiniMap)
        {
            camaraMapa.active = false;
            activeCanvasMiniMap = false;
            CanvasMiniMap.SetActive(false);
            MiniMap.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Player.GetComponent<PlayerMove>().canMoveToggle(true);
            Cursor.visible = false;
        }
    }
}