using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Interactor : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionRadius = 1.8f;
    [SerializeField] private LayerMask interactionMask;
    [SerializeField] private int numColliders;

    private readonly Collider[] colliders = new Collider[3];
    public bool interaction = false;
    public bool moveEnabled = true;
    public GameObject CanvasInteract;



    void Update()
    {
        if (photonView.IsMine)
        {
            numColliders = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionRadius, colliders, interactionMask);

            if (numColliders > 0)
            {
                var interactable = colliders[0].GetComponent<IInteractable>();

                if (interactable != null)
                {
                    CanvasInteract.SetActive(!interaction);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        interaction = !interaction;
                        moveEnabled = !moveEnabled;
                        GetComponent<PlayerMove>().canMoveToggle(moveEnabled);
                        interactable.Interact(this, interaction);
                    }
                }
            }
            else
            {
                CanvasInteract.SetActive(false);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRadius);
    }

    public void ForPauseMenu()
    {
        CanvasInteract.SetActive(false);
    }
}
