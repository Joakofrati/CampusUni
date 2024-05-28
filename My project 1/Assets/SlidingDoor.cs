using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SlidingDoor : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    public float openDistance = 1.0f; // Distancia que se abrirá cada puerta
    public float openSpeed = 2.0f;  // Velocidad de apertura/cierre
    public bool isOpen = false;  // Estado de la puerta

    private Vector3 closedPositionLeft;  // Posición cerrada inicial de la puerta izquierda
    private Vector3 closedPositionRight;  // Posición cerrada inicial de la puerta derecha
    private Vector3 openPositionLeft;  // Posición abierta de la puerta izquierda
    private Vector3 openPositionRight;  // Posición abierta de la puerta derecha

    private Vector3 targetPositionLeft;  // Posición objetivo actual de la puerta izquierda
    private Vector3 targetPositionRight;  // Posición objetivo actual de la puerta derecha

    void Start()
    {
        // Guardamos las posiciones iniciales (cerradas)
        closedPositionLeft = leftDoor.transform.localPosition;
        closedPositionRight = rightDoor.transform.localPosition;

        // Calculamos las posiciones abiertas
        openPositionLeft = closedPositionLeft + new Vector3(-openDistance, 0.0f, 0.0f);
        openPositionRight = closedPositionRight + new Vector3(openDistance, 0.0f, 0.0f);

        // Inicializamos las posiciones objetivo a las posiciones cerradas
        targetPositionLeft = closedPositionLeft;
        targetPositionRight = closedPositionRight;
    }

    void Update()
    {
        // Movemos las puertas hacia las posiciones objetivo
        leftDoor.transform.localPosition = Vector3.Lerp(leftDoor.transform.localPosition, targetPositionLeft, Time.deltaTime * openSpeed);
        rightDoor.transform.localPosition = Vector3.Lerp(rightDoor.transform.localPosition, targetPositionRight, Time.deltaTime * openSpeed);
    }

    // Método para abrir la puerta
    public void OpenDoor()
    {
        isOpen = true;
        targetPositionLeft = openPositionLeft;
        targetPositionRight = openPositionRight;
    }

    // Método para cerrar la puerta
    public void CloseDoor()
    {
        isOpen = false;
        targetPositionLeft = closedPositionLeft;
        targetPositionRight = closedPositionRight;
    }

    // Método para alternar el estado de la puerta
    void OnTriggerEnter()
    {
        OpenDoor();
    }

    void OnTriggerExit()
    {
        CloseDoor();
    }
}
