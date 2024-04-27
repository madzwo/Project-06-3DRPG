using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject bulletExplode;

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "enemy" || collision.tag == "obstacle")
        {
            Instantiate(bulletExplode, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
