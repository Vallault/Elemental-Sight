using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireProjectiles : MonoBehaviour
{
    public int ammo;
    public float cooldown;
    public float projectileForce;
    public GameObject projectile;
    public GameObject firingPoint;
    public bool canFire;


    public Slider slider;
    public float reloadRate;

    public UIManager uiManager;
    void Start()
    {
        canFire = true;


    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(canFire)
            {
                if(uiManager.fire > uiManager.fireCost)
                {
                    GameObject go = Instantiate(projectile, firingPoint.transform.position, firingPoint.transform.rotation);
                    //Quaternion angle = firingPoint.transform.rotation;
                    go.GetComponent<Rigidbody>().AddForce(firingPoint.transform.up * projectileForce, ForceMode.Impulse);
                    StartCoroutine(ProjectileCooldown());
                    uiManager.fire -= uiManager.fireCost;
                }
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
