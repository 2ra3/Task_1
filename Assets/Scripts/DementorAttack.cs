using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DementorAttack : MonoBehaviour {

	public float moveSpeed;
    public float maxDist;
    public float minDist;
    private GameObject player;

    // Update is called once per frame
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update () {
        transform.LookAt(player.transform);
        if (Vector3.Distance(transform.position, player.transform.position) >= minDist)
        {

            transform.position += transform.forward * moveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, player.transform.position) <= maxDist)
            {
                //Here Call any function U want Like Shoot at here or something

            }

        }

    }
}
