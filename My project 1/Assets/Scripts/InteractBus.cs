using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBus : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    public GameObject CanvasColectivoAzul;

    public string InteractionPrompt => prompt;

    public bool Interact(Interactor interactor, bool interaction)
    {
        CanvasColectivoAzul.SetActive(interaction);
        if (interaction)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (!interaction)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        return true;
    }

}