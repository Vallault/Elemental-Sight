using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : MonoBehaviour
{
    public GameObject rock;
    public GameObject particleEffects;
    public float rockDelay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(WaitToSpawnRock());
            particleEffects.SetActive(true);
        }
    }
    IEnumerator WaitToSpawnRock()
    {
        yield return new WaitForSeconds(rockDelay);
        rock.SetActive(true);
        yield return new WaitForSeconds(2);
        rock.GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 3);
    }
}

