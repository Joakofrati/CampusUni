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
        Text childText = Barra.GetComponentInChildren<Text>();
     
        switch (gameObject.name)
        {
            case "Pab3Butt":
                childText.text = "Pabellon 3";
           

            break;
             case "Pab1Butt":
                childText.text = "Pabellon 1";
   

            break;
        }
    }

}
