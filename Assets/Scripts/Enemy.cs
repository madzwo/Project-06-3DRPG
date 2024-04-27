using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    public float speed;
    public Rigidbody rb;
    private bool hasRotated = false;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 vel = transform.forward * speed - rb.velocity;
        rb.AddForce(vel, ForceMode.Force);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (!hasRotated && collision.gameObject.CompareTag("turn"))
        {
            Debug.Log("Turn");
            transform.Rotate(0, 90, 0);
            hasRotated = true;
        }
        if (collision.gameObject.CompareTag("strait"))
        {
            hasRotated = false;
        }
    }
}
