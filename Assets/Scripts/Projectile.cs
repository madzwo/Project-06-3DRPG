using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject bulletExplode;

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.tag != "player")
        {
            Instantiate(bulletExplode, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
