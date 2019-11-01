using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    //Speeds
    public float speed = 6.0f;
    public float turn = 90.0f;
    public float jump = 8.0f;
    public float gravity = 20.0f;

    private Vector3 movement = Vector3.zero;
    public CharacterController moveController;
    // Update is called once per frame
    void Update()
    {
        //If grounded
        if (moveController.isGrounded)
        {
            //Read vertical data
            float vertical = Input.GetAxis("Vertical");
            movement = new Vector3(0, 0, vertical);
            movement = transform.TransformDirection(movement);
            movement *= speed;
            //Jump
            if (Input.GetButton("Jump"))
            {
                movement.y = jump;
            }
        }
        //If not grounded
        else
        {
            movement.y -= gravity * Time.deltaTime;
        }
        transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * turn * Time.deltaTime);
        moveController.Move(movement * Time.deltaTime);
    }
}
