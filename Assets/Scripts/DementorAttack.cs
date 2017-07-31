using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DementorAttack : MonoBehaviour {

	public float moveSpeed;
    public float maxDist;
    public float minDist;
    public float rate;
    private GameObject player;
    private PlayerHealth playerHealth;
    //private GameController gameController;
    private GameObject gameController;

    // Update is called once per frame
     void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        gameController = GameObject.FindGameObjectWithTag("GameController");
       /* GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }*/

    }

    void Update () {
        transform.LookAt(player.transform);
        float difference = Vector3.Distance(transform.position, player.transform.position);
        if (difference >= 2)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        if ((difference >= minDist) && (difference <= maxDist))
        {


            //player is losing life
            playerHealth.TakeDamage(rate * Time.deltaTime);


        }

        else if (difference <= minDist)
            {

            //player is dead
            gameController.SetActive(false);
            playerHealth.Death();
            }

        

    }
}
