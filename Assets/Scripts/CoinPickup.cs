﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    public int value;
    public AudioClip coinCollected;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddCoin(value);
            AudioSource.PlayClipAtPoint(coinCollected, transform.position);

            Destroy(gameObject);
        }
    }
}
