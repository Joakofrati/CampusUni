using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBrownBus : MonoBehaviour
{
    public float distance = 2.5f;
    LayerMask mask;
    public bool activeBrownInterface;
    public GameObject CanvasColectivoMarron;
    public GameObject player;
    public GameObject CanvasInteract;

    void Start()
    {
        activeBrownInterface = false;
        ToggleCanvasVisibility(activeBrownInterface);
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
                if (hit.collider.tag == "BrownBus")
                {
                    activeBrownInterface = !activeBrownInterface;
                    ToggleCanvasVisibility(activeBrownInterface);
                    if (activeBrownInterface)
                    {
                        player.GetComponent<PlayerMove>().enabled = false;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;

                    }
                    if (!activeBrownInterface)
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
        CanvasColectivoMarron.SetActive(active);

    }
}
