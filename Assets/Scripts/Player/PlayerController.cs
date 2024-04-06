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
    
    public Player player;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        speed = player.speed;
        if(player.isAttacking || player.isEating || player.isDead)
        {
            moveDirection = Vector3.zero;
            animator.SetBool("IsWalking",false);
        }
        else
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Quaternion cameraRotation = Quaternion.Euler(0f, playerCamera.eulerAngles.y, 0f);
            moveDirection = cameraRotation * new Vector3(horizontalInput,0,verticalInput);
            transform.position += moveDirection * speed * Time.deltaTime;
        }
        if(!player.isDead)
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up * mouseX);

            float mouseY = Input.GetAxis("Mouse Y") * pitchSpeed;
            pitch -= mouseY;
            pitch = Mathf.Clamp(pitch, -10f, 40f); 
            playerCamera.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        }
        
        if (moveDirection != Vector3.zero)
        {
            animator.SetBool("IsWalking",true);
            animator.SetFloat("Speed",speed * 0.5f);
            
        }
        else
        {
            animator.SetBool("IsWalking",false);
        }
    }
}
