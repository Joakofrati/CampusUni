using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InfoButton : MonoBehaviour
{

    public GameObject Barra;
    public GameObject PopUp;
    public bool PopUpEnabler;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnOff);
        PopUpEnabler = false;
        
        PopUp.SetActive(PopUpEnabler);
        
    }

     void OnOff()
    {
        PopUpEnabler ^= true;
        
        Text childText = Barra.transform.Find("Nombre").GetComponent<Text>();
      
        Text info = PopUp.transform.Find("Info").gameObject.GetComponent<Text>();
        Text name = PopUp.transform.Find("Name").gameObject.GetComponent<Text>();
        String switcher = childText.text;
        switch (switcher)
        {
            case "Pabellon 3":
                name.text  = "Pabellon 3";
            break;
            case "Pabellon 1":
                info.text = "El pabellon 1 cuenta con 3 aulas, las cuáles son usadas como espacio para distintas facultades. También se encuentra en el lugar un cajero y un kiosko";
                name.text  = "Pabellon 1"; 
            break;
            case "Pabellon 2":
                name.text  = "Pabellon 2";
            break;
            case "Exactas":
                name.text  = "Exactas";
            break;
            case "Humanas":
                name.text  = "Humanas";
            break;
            case "Economicas":
                name.text  = "Economicas";
            break;
            case "Veterinaria":
                name.text  = "Veterinaria";
            break;
            case "Exactas/Pabellon 4":
                name.text  = "Exactas/Pabellon 4";
            break;
             case "Kiosco Economicas":
                name.text  = "Kiosco Economicas";
            break;
            case "Boxes de Investigación":
                name.text  = "Boxes de Investigación";
            break;
            case "Boxes de Investigación II":
                name.text  = "Boxes de Investigación II";
            break;
            case "IFIMAT":
                name.text  = "IFIMAT";
            break;
            case "ISISTAN":
                name.text  = "ISISTAN";
            break;
            case "PLADEMA":
                name.text  = "PLADEMA";
            break;
            case "Sanidad Animal":
                name.text  = "Sanidad Animal";
            break;
            case "Colectivos":
                name.text  = "Colectivos";
            break;
            case "Comedor":
                name.text  = "Comedor";
            break;
            case "Pabellon Veterinaria":
                name.text  = "Pabellon Veterinaria";
            break;
            case "Departamento de Producción Animal":
                name.text  = "Departamento de Producción Animal";
            break;
            case "Tecnología Alimentaria":
                name.text  = "Tecnología Alimentaria";
            break;
            case "Biblioteca":
                name.text  = "Biblioteca";
            break;
            case "Banco Santander":
                name.text  = "Banco Santander";
            break;
        }
        PopUp.SetActive(PopUpEnabler);
    }

}
