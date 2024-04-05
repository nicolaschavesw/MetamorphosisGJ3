using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float pitchSpeed, pitch;
    [SerializeField] private Vector3 moveDirection;
    public Transform playerCamera;
    public Animator animator;
    public float speed;
    public bool canMove;

    public Player player;
    void Start()
    {
        canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        speed = player.speed;
        if(!player.isAttacking)
        {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Quaternion cameraRotation = Quaternion.Euler(0f, playerCamera.eulerAngles.y, 0f);
        moveDirection = cameraRotation * new Vector3(horizontalInput,0,verticalInput);
        transform.position += moveDirection * speed * Time.deltaTime;
        }
        else
        {
            moveDirection = Vector3.zero;
        }

        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        float mouseY = Input.GetAxis("Mouse Y") * pitchSpeed;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -10f, 40f); 
        playerCamera.localRotation = Quaternion.Euler(pitch, 0f, 0f);

        if (moveDirection != Vector3.zero)
        {
            animator.SetBool("IsWalking",true);
            animator.SetFloat("Speed",speed * 0.1f);
            
        }
        else
        {
            animator.SetBool("IsWalking",false);
        }
    }
}
