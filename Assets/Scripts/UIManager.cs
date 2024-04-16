using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Slider iceSlider;
    public Slider fireSlider;
    public float reloadRate;

    public float fire;
    public float fireCost;
    public float maxFire;

    public float ice;
    public float iceCost;
    public float maxIce;

    public GameObject pausePanel;
    public GameObject deathPanel;
    public GameObject winPanel;


    void Start()
    {
        Time.timeScale = 1;
        fire = maxFire;
        ice = maxIce;
    }

    // Update is called once per frame
    void Update()
    {
        if (fire < maxFire)
            fire += reloadRate * Time.deltaTime;

        if (fire < 0) fire = 0;
        fireSlider.value = fire / maxFire;

        if(ice > maxIce) ice = maxIce;
        if(ice< 0) ice = 0;
        iceSlider.value = ice / maxIce;
        

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeInHierarchy)
            {
                Time.timeScale = 1;
                pausePanel.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
            }
        }
    }

    public void RunOutOfOxygen()
    {
        Time.timeScale = 0;
        deathPanel.SetActive(true);
    }


    public void LoadScene(string levelName)
    {
        
    }
}
