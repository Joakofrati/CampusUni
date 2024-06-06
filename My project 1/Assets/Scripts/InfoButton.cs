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
    public RawImage targetImage;
    public GameObject mensaje;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnOff);
        PopUpEnabler = false;
        PopUp.SetActive(PopUpEnabler);
    }

    void OnOff()
    {
        mensaje.SetActive(false); //HABER SI FUNCIONA ESTO
        PopUpEnabler ^= true;

        Text childText = Barra.transform.Find("NombreEdiBarra")?.GetComponent<Text>();
        if (childText == null)
        {
            Debug.LogError("childText is null");
            return;
        }

        // Adjusted to new hierarchy
        Transform imageTransform = PopUp.transform.Find("Image");
        if (imageTransform == null)
        {
            Debug.LogError("Image is null");
            return;
        }
        
        Transform contenidoTransform = PopUp.transform.Find("Contenido");
        if (contenidoTransform == null)
        {
            Debug.LogError("Contenido is null");
            return;
        }

        Text name = contenidoTransform.Find("NombreEdiInfo")?.GetComponent<Text>();
        if (name == null)
        {
            Debug.LogError("NombreEdiInfo is null");
            return;
        }

        Text info = contenidoTransform.Find("InfoEdi")?.GetComponent<Text>();
        if (info == null)
        {
            Debug.LogError("InfoEdi is null");
            return;
        }

        // Assuming 'targetImage' is still assigned via Inspector or other means
        if (targetImage == null)
        {
            Debug.LogError("targetImage is null");
            return;
        }

        String switcher = childText.text;
        Debug.Log(switcher);

        switch (switcher)
        {
            case "Pabellon 3":
                name.text = "Pabellon 3";
                info.text = "";
                break;
            case "Pabellon 1":
                info.text = "El pabellon 1 cuenta con 3 aulas, las cuáles son usadas como espacio para distintas facultades. También se encuentra en el lugar un cajero y un kiosko";
                name.text = "Pabellon 1";
                break;
            case "Pabellon 2":
                name.text = "Pabellon 2";
                info.text = "";
                break;
            case "Exactas":
                name.text = "Exactas";
                info.text = "";
                break;
            case "Humanas":
                name.text = "Humanas";
                info.text = "";
                break;
            case "Economicas":
                name.text = "Economicas";
                info.text = "";
                break;
            case "Veterinaria":
                name.text = "Veterinaria";
                info.text = "";
                break;
            case "Exactas/Pabellon 4":
                name.text = "Exactas/Pabellon 4";
                info.text = "";
                break;
            case "Kiosco Economicas":
                name.text = "Kiosco Economicas";
                info.text = "";
                break;
            case "Boxes de Investigación":
                name.text = "Boxes de Investigación";
                info.text = "";
                break;
            case "Boxes de Investigación II":
                name.text = "Boxes de Investigación II";
                info.text = "";
                break;
            case "IFIMAT":
                name.text = "IFIMAT";
                info.text = "";
                break;
            case "ISISTAN":
                name.text = "ISISTAN";
                info.text = "";
                break;
            case "PLADEMA":
                name.text = "PLADEMA";
                info.text = "";
                break;
            case "Sanidad Animal":
                name.text = "Sanidad Animal";
                info.text = "";
                break;
            case "Colectivos":
                name.text = "Colectivos";
                info.text = "";
                break;
            case "Comedor":
                name.text = "Comedor";
                info.text = "";
                break;
            case "Pabellon Veterinaria":
                name.text = "Pabellon Veterinaria";
                info.text = "";
                break;
            case "Departamento de Producción Animal":
                name.text = "Departamento de Producción Animal";
                info.text = "";
                break;
            case "Tecnología Alimentaria":
                name.text = "Tecnología Alimentaria";
                info.text = "";
                break;
            case "Biblioteca":
                name.text = "Biblioteca";
                info.text = "";
                break;
            case "Banco Santander":
                name.text = "Banco Santander";
                info.text = "";
                break;
        }
        Texture2D loadedTexture = Resources.Load<Texture2D>("ImagesInterior/" + name.text);
        Debug.Log(" png " + loadedTexture);
        if (loadedTexture != null)
        {   
            if (name.text is "Pabellon 1"){
                //contenidoTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(1200, 1000);
            }
            targetImage.texture = loadedTexture;
        }

        PopUp.SetActive(PopUpEnabler);
    }
}
