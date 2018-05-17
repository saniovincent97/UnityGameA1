using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

    public int damageAmount = 100;
    BoxCollider stomp;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider stomp)
    {
        if (stomp.gameObject.tag == "Player")
        {
            FindObjectOfType<HealthManager>().HurtEnemy(damageAmount);

        }
    }

}
