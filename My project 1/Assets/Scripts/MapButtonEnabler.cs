using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapButtonEnabler : MonoBehaviour
{

    public GameObject Barra;
    public bool barraEnabler;
    public GameObject mensaje;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BOTON");
        gameObject.GetComponent<Button>().onClick.AddListener(OnOff);
        barraEnabler = false;
        
        Barra.SetActive(barraEnabler);
    }

     void OnOff()
    {
        mensaje.SetActive(false); //EOOOO
        barraEnabler ^= true;
        Barra.SetActive(barraEnabler);
        Debug.Log("");
        Text childText = Barra.GetComponentInChildren<Text>();
     
        switch (gameObject.name)
        {
            case "Pab3Butt":
                childText.text = "Pabellon 3";
            break;
            case "Pab1Butt":
                childText.text = "Pabellon 1";
            break;
            case "ExaButt":
                childText.text = "Exactas";
            break;
            case "ExaPab4Butt":
                childText.text = "Exactas/Pabellon 4";
            break;
            case "Pab2Butt":
                childText.text = "Pabellon 2";
            break;
            case "EcoButt":
                childText.text = "Economicas";
            break;
            case "HumButt":
                childText.text = "Humanas";
            break;
            case "VeteButt":
                childText.text = "Veterinaria";
            break;
        }
    }

}
