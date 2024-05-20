using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivarMapa : MonoBehaviour
{
    private bool activeCanvasMiniMap;
    public GameObject CanvasMiniMap;
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
            Debug.Log("Entre");
            activeCanvasMiniMap = true;
            CanvasMiniMap.SetActive(true);
            MiniMap.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            //Player.GetComponent<PlayerMove>().enabled = false;
            Cursor.visible = true;

        }
        else if (Input.GetKeyDown(KeyCode.M) && activeCanvasMiniMap)
        {
            Debug.Log("Entre else");
            activeCanvasMiniMap = false;
            CanvasMiniMap.SetActive(false);
            MiniMap.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        //    Player.GetComponent<PlayerMove>().enabled = true;
            Cursor.visible = false;
        }
    }
}