using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public Rigidbody rB;

	// Use this for initialization
	void Start () {
        rB = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
        rB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
		
	}
}
