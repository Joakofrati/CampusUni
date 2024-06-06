using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Teleport : MonoBehaviour
{

    public GameObject Player;
    public GameObject Barra;
    public GameObject mensaje;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(TP);
    }

    // Update is called once per frame
    void TP()
    {
        mensaje.SetActive(false); //eoo
        Text childText = Barra.GetComponentInChildren<Text>();
        String switcher = childText.text;
        switch (switcher)
        {
            case "Pabellon 3":
            
                Player.GetComponent<Transform>().position = new Vector3(-1126.72998f,227.62f,-3740.77002f);

            break;
            case "Pabellon 1":
                Player.GetComponent<Transform>().position = new Vector3(-1125.06995f,228.759995f,-3699.90991f);
                 
            break;
            case "Pabellon 2":
                
            break;
            case "Exactas":
                Player.GetComponent<Transform>().position = new Vector3(-1016.53497f,231.615005f,-3564.0249f);
            break;
            case "Humanas":
                
            break;
            case "Economicas":
                
            break;
            case "Veterinaria":
                
            break;
            case "Exactas/Pabellon 4":
                
            break;
            case "Comedor":
                Player.GetComponent<Transform>().position = new Vector3(-1106.76001f,229.649994f,-3656.28003f);
            break;

        }
    }
}
