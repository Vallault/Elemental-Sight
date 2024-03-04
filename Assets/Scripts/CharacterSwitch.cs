using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public GameObject player1;
    public GameObject player2;
    void Start()
    {
        virtualCamera.Follow = player1.transform;
        virtualCamera.LookAt = player1.transform;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            virtualCamera.Follow = player1.transform;
            virtualCamera.LookAt = player1.transform;
            player1.GetComponent<PlayerController>().enabled = true;
            player1.GetComponent<Follower>().enabled = false;
            player2.GetComponent<PlayerController>().enabled = false;
            player2.GetComponent<Follower>().enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            virtualCamera.Follow = player2.transform;
            virtualCamera.LookAt = player2.transform;
            player2.GetComponent<PlayerController>().enabled = true;
            player2.GetComponent<Follower>().enabled = false;
            player1.GetComponent<PlayerController>().enabled = false;
            player1.GetComponent<Follower>().enabled = true;
        }
    }
}
