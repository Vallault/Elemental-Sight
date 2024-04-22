using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    public Slider slider;
    public float duration;
    public float maxDuration;
    public UIManager uIManager;
    public Collider myCollider;
    public GameObject[] players;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        myCollider = GetComponent<Collider>();
        duration = maxDuration;
        uIManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        duration-= 1 * Time.deltaTime;
        slider.value = duration/maxDuration;

        if(duration < 0)
        {
            uIManager.ice += uIManager.iceCost;
            Destroy(gameObject);
        }

        if (players[0].transform.position.y > gameObject.transform.position.y + 1 || players[1].transform.position.y > gameObject.transform.position.y + 1)
        {
            myCollider.enabled = true;
        }
        else
        {
            myCollider.enabled = false;
        }
    }
}
