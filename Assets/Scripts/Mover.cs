using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;

    

    void Start()
    {
       
    }

     void Update()
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * speed);
           
        }

    }
}
