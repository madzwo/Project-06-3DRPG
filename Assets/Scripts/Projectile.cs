using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject bulletExplode;
    public GameObject enemyExplode;

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "obstacle")
        {
            Instantiate(bulletExplode, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if(collision.tag == "enemy")
        {
            Instantiate(bulletExplode, transform.position, transform.rotation);
            Instantiate(enemyExplode, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
