using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    Vector3 moveDirection;
    public float moveSpeed;
    public float turnSpeed;
    private bool isMoving;

    public GameObject friend;
    public TMP_Text interactText;
    public float interactDistance;
    public bool isInteracting;

    private int dialogNumber;
    public TMP_Text dialogOneText;
    public TMP_Text dialogTwoText;
    public TMP_Text dialogThreeText;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        isInteracting = false;
        dialogNumber = 1;
        
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
            Vector3 moveDirection = -transform.forward * (moveSpeed * 0.6f);
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

        if(Vector3.Distance(transform.position, friend.transform.position) <= interactDistance)
        {
            if (isInteracting)
            {
                if(Input.GetKeyDown(KeyCode.F))
                {
                    dialogNumber++;
                }
                if(dialogNumber == 1)
                {
                    interactText.gameObject.SetActive(false);
                    dialogOneText.gameObject.SetActive(true);
                }
                if(dialogNumber == 2)
                {
                    dialogOneText.gameObject.SetActive(false);
                    dialogTwoText.gameObject.SetActive(true);
                }
                if(dialogNumber == 3)
                {
                    dialogTwoText.gameObject.SetActive(false);
                    dialogThreeText.gameObject.SetActive(true);
                }
                if(dialogNumber == 4)
                {
                    dialogThreeText.gameObject.SetActive(false);
                    isInteracting = false;
                    dialogNumber = 1;
                }
            }
            else 
            {
                interactText.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.F))
                {
                    isInteracting = true;
                }
            }
        }
        else
        {
            isInteracting = false;
            interactText.gameObject.SetActive(false);
            dialogOneText.gameObject.SetActive(false);
            dialogTwoText.gameObject.SetActive(false);
            dialogThreeText.gameObject.SetActive(false);
            dialogNumber = 1;
        }
    }
}
