using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceProjectiles : MonoBehaviour
{
    public GameObject platform;
    public GameObject platformGhost;
    public bool ghostActive;

    public UIManager uiManager;


    private void Start()
    {

    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(ghostActive == false)
            {
                ghostActive = true;
                platformGhost.SetActive(true);
            }
            else
            {
                if(uiManager.ice >= uiManager.iceCost)
                {
                    Instantiate(platform, platformGhost.transform.position, platformGhost.transform.rotation);
                    uiManager.ice -= uiManager.iceCost;
                }

            }
        }
        if(ghostActive)
        {
            GhostPosition();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ghostActive = false;
            platformGhost.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ghostActive = false;
            platformGhost.SetActive(false);
        }
    }

    void GhostPosition()
    {
        // Get the mouse position in screen space
        Vector3 mousePositionScreen = Input.mousePosition;

        // Set a constant distance from the camera to the object in world space
        mousePositionScreen.z = 20f;

        // Convert the mouse position to world space
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);


        platformGhost.transform.position = mousePositionWorld;
    }
}
