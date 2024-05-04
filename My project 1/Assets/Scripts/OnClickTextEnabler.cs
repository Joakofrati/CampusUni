using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickTextEnabler : MonoBehaviour
{

    public GameObject Text;
    public bool textEnabler;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnOff);
        textEnabler = false;
        Text.SetActive(textEnabler);
        
    }

    
    void OnOff()
    {
        textEnabler ^= true;
        Text.SetActive(textEnabler);
    }

    

}
