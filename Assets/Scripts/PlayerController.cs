using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float rollSpeed;
    //public Rigidbody rB;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;


    public Animator anim;
    public Transform pivot;
    public float rotateSpeed;
    public GameObject playerModel;
    public AudioClip jumpSound;
    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;

    private bool walking = true;
    public Transform smoke;

	// Use this for initialization
	void Start () {
        //rB = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        smoke.GetComponent<ParticleSystem>().enableEmission = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        /*rB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        if(Input.GetButtonDown("Jump"))
        {
           rB.velocity = new Vector3(rB.velocity.x, jumpForce, rB.velocity.z);
        }*/

        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        if(knockBackCounter <= 0)
        {
            float yStore = moveDirection.y;
            moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
            moveDirection = moveDirection.normalized * moveSpeed;
            moveDirection.y = yStore;

            if (controller.isGrounded)
            {
                moveDirection.y = 0f;
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                    AudioSource.PlayClipAtPoint(jumpSound, transform.position);

                }


                if (Input.GetButtonDown("Roll"))
                {
                    anim.SetTrigger("Rolling");
                }
                
                

            }
           

            if (Input.GetButtonDown("Sprint"))
            {
                if (walking)
                {
                    moveSpeed = sprintSpeed;
                    walking = false;
                    smoke.GetComponent<ParticleSystem>().enableEmission = true;

                }
                else
                {
                    moveSpeed = walkSpeed;
                    walking = true;
                    smoke.GetComponent<ParticleSystem>().enableEmission = false;
                    
                }
            }

          
           
            
            

            if (walking == false)
                anim.SetBool("Walking", false);


            if (walking == true)
                anim.SetBool("Walking", true);
                


            if (controller.velocity.magnitude == 0)
            {
                smoke.GetComponent<ParticleSystem>().enableEmission = false;
            }

            if (controller.velocity.magnitude > 0 && walking == false)
            {
                smoke.GetComponent<ParticleSystem>().enableEmission = true;
            }

            if(controller.isGrounded == false)
            {
                smoke.GetComponent<ParticleSystem>().enableEmission = false;
            }


        } else
        {
            knockBackCounter -= Time.deltaTime;
        }


        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

        anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));

    }


    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;
        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;
    }

}
