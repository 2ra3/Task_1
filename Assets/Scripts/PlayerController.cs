using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
    public float speed;
    private AudioSource a;

    private Rigidbody rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        a = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            a.Play();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);

        rb.AddForce(movement * speed);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        
    }
}