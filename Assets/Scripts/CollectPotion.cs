using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPotion : MonoBehaviour {


    private GameObject player;
    private PlayerHealth playerHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            playerHealth.AddLife(10);

        }
    }
}
