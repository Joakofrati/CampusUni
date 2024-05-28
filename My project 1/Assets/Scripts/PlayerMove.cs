using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviourPunCallbacks
{
    public GameObject miniMapCamera; //NUEVO

    public GameObject playerCamera;
    public Camera player3Camera;
    public float walkSpeed = 6f;
    public float runSpeed = 9f;
    // public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public float defaultHeight = 1.9f;

    private Vector3 moveDirection = Vector3.zero;

    private float rotationX = 0;
    private CharacterController characterController;

    private bool isWaving = false;

    private bool canMove = true;
    public float rotationSpeed = 250;

    public Animator animator;

    private float y,x;

    void Start()
    {
        
        if (!photonView.IsMine)
        {
            playerCamera.GetComponent<Camera>().enabled = false;
            player3Camera.enabled = false;

        }
        else if (CompareTag("Player") && photonView.IsMine)
        {
            characterController = GetComponent<CharacterController>();
            player3Camera = transform.Find("Camera3ra").GetComponent<Camera>();
            playerCamera = transform.Find("Camera").gameObject;
            animator = GetComponent <Animator>();
            miniMapCamera = transform.Find("CameraMiniMap").gameObject;
            miniMapCamera.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        
    }
    void Update()
    {
if (photonView.IsMine)
        {
            // Iniciar la animación de saludo
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.SetTrigger("Waving");
            }
            // Verificar si está saludando
            bool isWaving = animator.GetCurrentAnimatorStateInfo(0).IsName("Waving");
            if (canMove && !isWaving)
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 right = transform.TransformDirection(Vector3.right);
                if (Input.GetKeyDown(KeyCode.T))
                {
                    playerCamera.GetComponent<Camera>().enabled = !playerCamera.GetComponent<Camera>().enabled;
                    player3Camera.enabled = !playerCamera.GetComponent<Camera>().enabled;
                }

                bool isRunning = Input.GetKey(KeyCode.LeftShift);
                animator.SetBool("Running", isRunning);
                float curSpeedX = (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical");
                float curSpeedY = (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal");
                float movementDirectionY = moveDirection.y;
                moveDirection = (forward * curSpeedX) + (right * curSpeedY);
                if (isRunning)
                {
                    playerCamera.transform.localPosition = new Vector3(0f, 1.635f, 0.35f);
                }
                else
                {
                    playerCamera.transform.localPosition = new Vector3(0f, 1.635f, 0.25f);
                }

                animator.SetFloat("VelX", curSpeedY);
                animator.SetFloat("VelY", curSpeedX);;

                // if (Input.GetButton("Jump") && characterController.isGrounded)
                // {
                //     moveDirection.y = jumpPower;
                // }
                // else
                // {
                    moveDirection.y = movementDirectionY;
                // }

                if (!characterController.isGrounded)
                {
                    moveDirection.y -= gravity * Time.deltaTime;
                }

                characterController.height = defaultHeight;
                walkSpeed = 3.2f;
                runSpeed = 5f;

                characterController.Move(moveDirection * Time.deltaTime);

                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                player3Camera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            }
            else
            {
                    moveDirection = Vector3.zero;
                    characterController.Move(moveDirection * Time.deltaTime);
            }
            
        } 
    }

    public void canMoveToggle(bool activar){
        canMove = activar;
    }

    public void teleport(Vector3 posicion){
        characterController.enabled = false;
        transform.position = posicion;
        characterController.enabled = true;
        
    }
}
