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

    public UIManager uiManager;
    void Start()
    {
        oxygen = maxOxygen;
    }

    // Update is called once per frame
    void Update()
    {
        oxygen -= drainRate * Time.deltaTime;
        oxygenSlider.value = oxygen / maxOxygen;

        if(oxygen < 0)
        {
            uiManager.RunOutOfOxygen();
        }
        if(oxygen > maxOxygen)
        {
            oxygen = maxOxygen;
        }
    }
}
