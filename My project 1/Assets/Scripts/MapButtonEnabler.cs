using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapButtonEnabler : MonoBehaviour
{

    public GameObject Barra;
    public bool barraEnabler;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnOff);
        barraEnabler = false;
        
        Barra.SetActive(barraEnabler);
    }

     void OnOff()
    {
        barraEnabler ^= true;
        Barra.SetActive(barraEnabler);
        Text childText = Barra.transform.Find("Nombre").GetComponent<Text>();
     
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
            case "PabEconomicasButt":
                childText.text = "Economicas";
            break;
            case "PabKioscoEcoButt":
                childText.text = "Kiosco Economicas";
            break;
            case "PabHumanasButt":
                childText.text = "Humanas";
            break;
            case "Vete3Butt":
                childText.text = "Veterinaria";
            break;
            case "Vete2Butt":
            case "VeteButt":
                childText.text = "Pabellon Veterinaria";
            break;
            case "BoxesInvesButt":
                childText.text = "Boxes de Investigación";
            break;
            case "BancoButt":
                childText.text = "Banco Santander";
            break;
            case "ComedorButt":
                childText.text = "Comedor";
            break;
            case "IsistanButt":
                childText.text = "ISISTAN";
            break;
            case "IfimatButt":
                childText.text = "IFIMAT";
            break;
            case "TecAlimButt":
                childText.text = "Tecnología Alimentaria";
            break;
            case "BoxesInves2Butt":
                childText.text = "Boxes de Investigación II";
            break;
            case "DepProdAnimalButt":
                childText.text = "Departamento de Producción Animal";
            break;
            case "SanidadAnimalButt":
                childText.text = "Sanidad Animal";
            break;
            case "PlademaButt":
                childText.text = "PLADEMA";
            break;
            case "ColesButt":
                childText.text = "Colectivos";
            break;
            case "BibliotecaButt":
                childText.text = "Biblioteca";
            break;
        }
    }

}
