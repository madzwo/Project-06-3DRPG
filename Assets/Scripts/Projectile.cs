using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public void OnTriggerEnter(Collider collision)
    {
        if(collision.tag != "player")
        {
            Destroy(gameObject);
        }
    }
}
