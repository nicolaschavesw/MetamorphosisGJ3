using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MtestScript : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;
    public Vector2 turn;
    public float gravity = 10f;
    public float alturaJump = 2f;
    public Vector3 movement = Vector3.zero;

    public CharacterController foxPlayer;

    public float playerSpeed = 10f;
// -----------------------------------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        foxPlayer = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }
// -----------------------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        turn.x += Input.GetAxis("Mouse X");

        if (foxPlayer.isGrounded)
        {
            movement = new Vector3(horizontalMove, 0f, verticalMove);
            movement = transform.TransformDirection(movement) * playerSpeed;

        }

        if (Input.GetButtonDown("Jump"))
        {
            movement.y = alturaJump;
        }

        movement.y -= gravity * Time.deltaTime;

        /*  foxPlayer.Move(new Vector3(horizontalMove,0,verticalMove) * playerSpeed * Time.deltaTime); */
        foxPlayer.Move(movement * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            foxPlayer.Move(movement * Time.deltaTime * 2f);
        }
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
