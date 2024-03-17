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
    void Start()
    {
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
    }
}
