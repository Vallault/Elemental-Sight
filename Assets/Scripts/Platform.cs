using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    public Slider slider;
    public float duration;
    public float maxDuration;
    void Start()
    {
        duration = maxDuration;
    }

    // Update is called once per frame
    void Update()
    {
        duration-= 1 * Time.deltaTime;
        slider.value = duration/maxDuration;

        if(duration < 0)
        {
            Destroy(gameObject);
        }
    }
}
