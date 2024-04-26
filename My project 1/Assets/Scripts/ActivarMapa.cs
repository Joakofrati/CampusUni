using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivarMapa : MonoBehaviour
{
     private bool activeCanvasMiniMap;
    public GameObject CanvasMiniMap;

    void Start()
    {
        activeCanvasMiniMap = false;
        ToggleCanvasVisibility(activeCanvasMiniMap);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeCanvasMiniMap = !activeCanvasMiniMap; // Cambia el estado opuesto
            ToggleCanvasVisibility(activeCanvasMiniMap);
            Debug.Log(activeCanvasMiniMap ? "Lo activo" : "Lo desactivo");
        }
    }

    void ToggleCanvasVisibility(bool active)
    {
        CanvasMiniMap.SetActive(active);
        
    }
}