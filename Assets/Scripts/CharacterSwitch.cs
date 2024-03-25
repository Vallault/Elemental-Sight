using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public GameObject player1;
    public GameObject player2;
    public GameObject player1UI;
    public GameObject player2UI;
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
            player1.GetComponent<PlayerController>().selectedCharacter.SetActive(true);
            player1.GetComponent<IceProjectiles>().enabled = true;

            player2.GetComponent<PlayerController>().selectedCharacter.SetActive(false);
            player2.GetComponent<PlayerController>().enabled = false;
            player2.GetComponent<Follower>().enabled = true;
            player2.GetComponent<FireProjectiles>().enabled = false;

            player1UI.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            player2UI.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            virtualCamera.Follow = player2.transform;
            virtualCamera.LookAt = player2.transform;
            player2.GetComponent<PlayerController>().enabled = true;
            player2.GetComponent<Follower>().enabled = false;
            player2.GetComponent<PlayerController>().selectedCharacter.SetActive(true);
            player2.GetComponent<FireProjectiles>().enabled = true;

            player1.GetComponent<IceProjectiles>().enabled = false;
            player1.GetComponent<PlayerController>().enabled = false;
            player1.GetComponent<Follower>().enabled = true;
            player1.GetComponent<PlayerController>().selectedCharacter.SetActive(false);

            player1UI.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            player2UI.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        }
    }
}
