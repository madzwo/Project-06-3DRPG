using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    Vector3 moveDirection;
    public float moveSpeed;
    public float turnSpeed;
    private bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            Vector3 moveDirection = transform.forward * moveSpeed;
            rb.AddForce(moveDirection);
            isMoving = true;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            Vector3 moveDirection = -transform.forward * moveSpeed;
            rb.AddForce(moveDirection);
            isMoving = true;
        } 
        else 
        {
            isMoving = false;
        }

        if (isMoving)
        {         
            if (Input.GetKey(KeyCode.A))
            {
                float rotationAmount = turnSpeed * Time.deltaTime;
                rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, -rotationAmount, 0f));
            }
            if (Input.GetKey(KeyCode.D))
            {
                float rotationAmount = turnSpeed * Time.deltaTime;
                rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, rotationAmount, 0f));
            }
        }
    }
}
