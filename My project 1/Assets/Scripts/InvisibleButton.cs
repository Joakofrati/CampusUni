using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvisibleButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Color newColor = gameObject.GetComponent<RawImage>().color;
        newColor.a = 0;
        gameObject.GetComponent<RawImage>().color = newColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
