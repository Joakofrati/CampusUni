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
        //Text name
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
                info.text = "El pabellon 1 cuenta con ";
                name.text  = "Pabellon 1";
                
            break;
        }
        PopUp.SetActive(PopUpEnabler);
    }

}
