using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    //private Rigidbody rb;

    //private GameObject dementor;
    public GameObject potion;
    public float pokeForce;
    

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //dementor = GameObject.FindGameObjectWithTag("Dementor");
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            return;
        }
        else if (other.tag == "Player")
        {
            return;
        }
        else if (other.tag == "Ground")
        {
            return;
        }
        else
        {
            //Destroy(other.gameObject);
            Destroy(gameObject);
           
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForceAtPosition(ray.direction * pokeForce, hit.point);
                    //potion fall
                    if (Random.value <= 0.5f)//50% chance of getting a potion to get 10% life
                    {
                        Instantiate(potion, hit.transform.position, Quaternion.identity);

                    }

                }
                
            
        }

    }
    
}
