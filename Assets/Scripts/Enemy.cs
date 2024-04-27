using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    public float speed;
    public Rigidbody rb;
    private bool hasRotated = false;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed;
    public float fireRate;
    private float timeTillFire;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 vel = transform.forward * speed - rb.velocity;
        rb.AddForce(vel, ForceMode.Force);
        
        if(timeTillFire <= 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * bulletSpeed, ForceMode.Force);
            timeTillFire = fireRate;
        }
        timeTillFire -= Time.deltaTime;
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
