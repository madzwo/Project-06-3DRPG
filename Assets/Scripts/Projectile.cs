using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
        if(gameObject.tag == "playerBullet")
        {
            if(collision.tag == "enemy")
            {
                Instantiate(bulletExplode, transform.position, transform.rotation);
                Instantiate(enemyExplode, transform.position, transform.rotation);
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
        else if(gameObject.tag == "enemyBullet")
        {
            if(collision.tag == "player")
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
