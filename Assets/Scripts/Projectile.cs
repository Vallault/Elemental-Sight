using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject eplosionParticle;

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(eplosionParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
