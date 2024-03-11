using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectiles : MonoBehaviour
{
    public int ammo;
    public float cooldown;
    public float projectileForce;
    public GameObject projectile;
    public GameObject firingPoint;
    public bool canFire;
    void Start()
    {
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(canFire)
            {
                GameObject go = Instantiate(projectile, firingPoint.transform.position, firingPoint.transform.rotation);
                //Quaternion angle = firingPoint.transform.rotation;
                go.GetComponent<Rigidbody>().AddForce(firingPoint.transform.up * projectileForce, ForceMode.Impulse);
                StartCoroutine(ProjectileCooldown());
            }
        }
    }
    IEnumerator ProjectileCooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(cooldown);
        canFire = true;
    }
}
