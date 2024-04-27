using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    public float speed;
    public Rigidbody rb;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 vel = transform.forward * speed - rb.velocity;
        rb.AddForce(vel, ForceMode.Force);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "turn")
        {
            Debug.Log("turn");
        }
    }
}
