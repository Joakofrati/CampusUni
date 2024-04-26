using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    public GameObject playerCamera;
    public Camera player3Camera;
    public float walkSpeed = 6f;
    public float runSpeed = 12;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public float defaultHeight = 1.9f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;

    private Vector3 moveDirection = Vector3.zero;

    private float rotationX = 0;
    private CharacterController characterController;

    private bool canMove = true;
    public float rotationSpeed = 250;

    public Animator animator;

    private float y,x;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        //Debug.Log(Input.GetKey(KeyCode.T));
        playerCamera.GetComponent<Camera>().enabled = !Input.GetKey(KeyCode.T);
        player3Camera.enabled = Input.GetKey(KeyCode.T);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        animator.SetBool("Running", isRunning);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        if (isRunning){
            playerCamera.transform.localPosition = new Vector3(0f,1.635f,0.25f);
        } else {
            playerCamera.transform.localPosition = new Vector3(0f,1.635f,0.15f);
        }

        animator.transform.localPosition = new Vector3(0f, 25f, 0f);
        animator.SetFloat("VelX",curSpeedY);
        animator.SetFloat("VelY",curSpeedX);
        animator.SetBool("Saltando", Input.GetButton("Jump"));
        // Debug.Log("Jump: " + Input.GetButton("Jump")+  " CanMove: "+ canMove+ " IsGrounded: "+characterController.isGrounded);
        // Debug.Log(Input.GetButton("Jump") && canMove && characterController.isGrounded);
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            animator.SetBool("Saltando",true);
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.R) && canMove)
        {
            characterController.height = crouchHeight;
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed;

        }
        else
        {
            characterController.height = defaultHeight;
            walkSpeed = 3.2f;
            runSpeed = 5f;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            player3Camera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

    }
}
