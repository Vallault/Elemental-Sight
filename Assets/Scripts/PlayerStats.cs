using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float oxygen;
    public float maxOxygen;
    public float drainRate;
    public Slider oxygenSlider;
    void Start()
    {
        oxygen = maxOxygen;
    }

    // Update is called once per frame
    void Update()
    {
        oxygen -= drainRate * Time.deltaTime;
        oxygenSlider.value = oxygen / maxOxygen;
    }
}
