using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Teleport : MonoBehaviour
{

    public GameObject Player;
    public GameObject Barra;
    // Start is called before the first frame update
    void Start()
    {
        this.Player = GameObject.FindGameObjectWithTag("Player");
        gameObject.GetComponent<Button>().onClick.AddListener(TP);
    }

    // Update is called once per frame
    void TP()
    {
        Text childText = Barra.transform.Find("Nombre").GetComponent<Text>();
        String switcher = childText.text;
        Debug.Log(childText.text);
        switch (switcher)
        {
            case "Pabellon 3":
            
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-1126.72998f,227.62f,-3740.77002f));

            break;
            case "Pabellon 1":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-1125.06995f,228.759995f,-3699.90991f));  
            break;
            case "Pabellon 2":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-1055.05579f,233f,-3489.22729f));
            break;
            case "Exactas":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-1020.409f,231f,-3559.083f));
            break;
            case "Humanas":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-1125.44739f,233.5f,-3490.58496f));
                
            break;
            case "Economicas":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-1096.37756f,231f,-3553.52148f));
            break;
            case "Veterinaria":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-1138.59937f,229f,-3682.57422f));
            break;
            case "Pabellon Veterinaria":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-1217.45154f,233f,-3675.73755f));
            break;
            case "Departamento de Producción Animal":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-1255.76904f,235f,-3646.41699f));
            break;
            case "Tecnología Alimentaria":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-1279.45044f,235f,-3604.90332f));
            break;
            case "Biblioteca":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-1198.51233f,233.7f,-3574.88867f));
            break;
            case "Banco Santander":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-1056.24915f,230f,-3610.92725f));
            break;
            case "Exactas/Pabellon 4":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-967.163452f,231f,-3546.19263f));
            break;
            case "Comedor":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-1110.07239f,229f,-3663.95044f));
            break;
            case "Kiosco Economicas":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-1082.02039f,230f,-3580.70557f));
            break;
            case "Boxes de Investigación":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-1029.59631f,232f,-3515.97461f));
            break;
            case "Boxes de Investigación II":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-1053.33325f,234f,-3441.74316f));
            break;
            case "IFIMAT":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-999.050781f,228f,-3626.53345f));
            break;
            case "ISISTAN":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-974.321289f,226.5f,-3670.97412f));
            break;
            case "PLADEMA":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-974.83252f,224f,-3728.14551f));
            break;
            case "Sanidad Animal":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-1106.04858f,225.5f,-3803.20483f));
            break;
            case "Colectivos":
                Player.GetComponent<PlayerMove>().teleport(new Vector3(-1146.51233f,227f,-3747.31055f));
            break;
        }
    }
}
