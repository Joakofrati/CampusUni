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
        
        Text childText = Barra.GetComponentInChildren<Text>();
      
        Text info = PopUp.transform.Find("Info").gameObject.GetComponent<Text>();
        Text name = PopUp.transform.Find("Name").gameObject.GetComponent<Text>();
        String switcher = childText.text;
        switch (switcher)
        {
            case "Pabellon 3":
                info.text = "El pabellon 3 cuenta con ";
                name.text  = "Pabellon 3";
            break;
            case "Pabellon 1":
                info.text = "El pabellon 1 cuenta con 3 aulas, las cuales son usadas ";
                name.text  = "Pabellon 1"; 
            break;
            case "Pabellon 2":
                info.text = "El pabellon 2 cuenta con ";
                name.text  = "Pabellon 2";
            break;
            case "Exactas":
                info.text = "La facultad de Exactas cuenta con ";
                name.text  = "Exactas";
            break;
            case "Humanas":
                info.text = "La facultad de Humanas cuenta con ";
                name.text  = "Humanas";
            break;
            case "Economicas":
                info.text = "La facultad de Economicas cuenta con ";
                name.text  = "Economicas";
            break;
            case "Veterinaria":
                info.text = "La facultad de Veterinaria cuenta con ";
                name.text  = "Veterinaria";
            break;
            case "Exactas/Pabellon 4":
                info.text = "...";
                name.text  = "Exactas/Pabellon 4";
            break;

        }
        PopUp.SetActive(PopUpEnabler);
    }

}
