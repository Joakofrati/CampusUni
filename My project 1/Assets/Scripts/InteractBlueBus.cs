using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBlueBus : MonoBehaviour
{
    public float distance = 2.5f;
    LayerMask mask;
    public bool activeBlueInterface;
    public GameObject CanvasColectivoAzul;
    public GameObject player;
    public GameObject CanvasInteract;

    // Start is called before the first frame update
    void Start()
    {
        activeBlueInterface = false;
        ToggleCanvasVisibility(activeBlueInterface);
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
                if (hit.collider.tag == "BlueBus")
                {
                    activeBlueInterface = !activeBlueInterface;
                    ToggleCanvasVisibility(activeBlueInterface);
                    if (activeBlueInterface)
                    {
                      //  Debug.Log("TRUE ACTIVE");
                        player.GetComponent<PlayerMove>().enabled = false;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;

                    }
                    if (!activeBlueInterface)
                    {
                       // Debug.Log("FALSE ACTIVE");
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
        CanvasColectivoAzul.SetActive(active);

    }
}
