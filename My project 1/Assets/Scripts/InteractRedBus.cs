using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRedBus : MonoBehaviour
{
    public float distance = 2.5f;
    LayerMask mask;
    public bool activeRedInterface;
    public GameObject CanvasColectivoRojo;
    public GameObject player;
    public GameObject CanvasInteract;

    void Start()
    {
        activeRedInterface = false;
        ToggleCanvasVisibility(activeRedInterface);
        mask = LayerMask.GetMask("Raycast Detect");
        CanvasInteract.SetActive(false);
    }

    void Update()
    {
        //Raycast(origen, dirección, out hit, distancia, máscara)
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, mask))
        {
            CanvasInteract.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.tag == "RedBus")
                {
                    activeRedInterface = !activeRedInterface;
                    ToggleCanvasVisibility(activeRedInterface);
                    if (activeRedInterface)
                    {
                        player.GetComponent<PlayerMove>().enabled = false;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;

                    }
                    if (!activeRedInterface)
                    {
                        player.GetComponent<PlayerMove>().enabled = true;
                        Cursor.lockState = CursorLockMode.Locked;
                        Cursor.visible = false;

                    }
                }
            }
        }
        else
        {
            CanvasInteract.SetActive(false);
        }
    }

    void ToggleCanvasVisibility(bool active)
    {
        CanvasColectivoRojo.SetActive(active);

    }
}
