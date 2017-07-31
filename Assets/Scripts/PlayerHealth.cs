using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float startingHealth = 50;
    public float currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    private GameObject player;
    //Animator anim;

    PlayerController playerController;
    bool isDead;
    bool damaged ;

    void Awake () {
        //anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = GetComponent<PlayerController>();
        currentHealth = startingHealth;
        damaged = false;
        isDead = false;
        healthSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
    }


    public void TakeDamage(float amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        // Play the hurt sound effect.
        //playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }
    public void AddLife(float amount)
    {
        if (currentHealth <= 100)
        {
            currentHealth += amount;
            healthSlider.value = currentHealth;
        }
    }


    public void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
        currentHealth = 0;
        healthSlider.value = currentHealth;
        // Turn off any remaining shooting effects(dont have any).
        //playerController.DisableEffects();


        // Tell the animator that the player is dead.
        //anim.SetTrigger("Die");

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        //playerAudio.clip = deathClip;
        //playerAudio.Play();

        // Turn off the movement and shooting scripts.
        playerController.enabled = false;
        
        player.SetActive(false);
        
    }

}
