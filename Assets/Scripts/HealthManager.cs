using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public int currentHealth;
    public int enemyHealth = 100;
    public int maxHealth;
    public Text healthText;
    public PlayerController player;
    public float invincibilityLength;
    private float invincibilityCounter;
    public AudioClip hurtSound;
    public Renderer playerRenderer;
    private float flashCounter;
    public float flashLength = 0.1f;


    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        player = FindObjectOfType<PlayerController>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if(invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                flashCounter = flashLength;
            }

            if(invincibilityCounter <= 0)
            {
                playerRenderer.enabled = true;
            }
        }
		
	}

    public void HurtPlayer(int damage, Vector3 direction)
    {
        if(invincibilityCounter <= 0)
        {
            currentHealth -= damage;
            player.Knockback(direction);
            invincibilityCounter = invincibilityLength;
            AudioSource.PlayClipAtPoint(hurtSound, transform.position);
            healthText.text = "" + currentHealth;

            playerRenderer.enabled = false;
            flashCounter = flashLength;
        }
        
    }

    public void HurtEnemy(int damage)
    {
        enemyHealth -= damage;
      
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
