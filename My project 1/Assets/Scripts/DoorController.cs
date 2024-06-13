using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class DoorController : MonoBehaviourPunCallbacks, IPunObservable
{
    public float doorOpenAngle = 90f; // Ángulo de apertura de la puerta
    public float openSpeed = 1.5f; // Velocidad de apertura de la puerta
    public KeyCode interactKey = KeyCode.E; // Tecla para interactuar

    public GameObject canvasInteract;
    private GameObject pauseMenu;
    private PauseMenu pauseMenuScript;

    private bool isOpen = false; // Estado de la puerta (abierta/cerrada)
    private bool isInRange = false; // Indica si el jugador está cerca

    private Quaternion doorOpenRotation;
    private Quaternion doorClosedRotation;
    private Transform doorTransform;

    void Start()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenuScript = pauseMenu.GetComponent<PauseMenu>();

        // Guardar las rotaciones de la puerta (abierta y cerrada)
        doorClosedRotation = transform.rotation;
        doorOpenRotation = Quaternion.Euler(0, doorOpenAngle, 0) * doorClosedRotation;

        // Obtener el transform de la puerta
        doorTransform = transform;
    }

    void Update()
    {
        // Si el jugador está cerca y presiona la tecla especificada
        if (isInRange && Input.GetKeyDown(interactKey))
        {
            // Cambiar el estado de la puerta
            isOpen = !isOpen;
            photonView.RPC("ToggleDoor", RpcTarget.All, isOpen);
        }

        // Llamar a la función para abrir/cerrar la puerta
        if (isOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    [PunRPC]
    void ToggleDoor(bool newState)
    {
        isOpen = newState;
    }

    // Método para abrir la puerta
    void OpenDoor()
    {
        doorTransform.rotation = Quaternion.Slerp(doorTransform.rotation, doorOpenRotation, openSpeed * Time.deltaTime);
    }

    // Método para cerrar la puerta
    void CloseDoor()
    {
        doorTransform.rotation = Quaternion.Slerp(doorTransform.rotation, doorClosedRotation, openSpeed * Time.deltaTime);
    }

    // Cuando el jugador entra en el rango de la puerta
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            if (!pauseMenuScript.isPause)
            {
                canvasInteract.SetActive(true);
            }
            
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            if (!pauseMenuScript.isPause)
            {
                canvasInteract.SetActive(true);
            }
        }
    }

    // Cuando el jugador sale del rango de la puerta
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            canvasInteract.SetActive(false);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(isOpen);
        }
        else
        {
            isOpen = (bool)stream.ReceiveNext();
        }
    }

    public void ForPauseMenu()
    {
        canvasInteract.SetActive(false);
    }
}
