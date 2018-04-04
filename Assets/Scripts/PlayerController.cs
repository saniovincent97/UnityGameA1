using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    //public Rigidbody rB;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

	// Use this for initialization
	void Start () {
        //rB = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
		
	}
	
	// Update is called once per frame
	void Update () {
        /*rB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        if(Input.GetButtonDown("Jump"))
        {
           rB.velocity = new Vector3(rB.velocity.x, jumpForce, rB.velocity.z);
        }*/

        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }

        }


        

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

    }
}
