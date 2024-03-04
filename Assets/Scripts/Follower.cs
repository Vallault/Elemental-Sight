using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public GameObject player;
    public float distance;
    public Vector3 offset;
    private Rigidbody rb;
    public float jumpForce;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CalculateDistanceToPlayer();

    }

    void CalculateDistanceToPlayer()
    {
        if(player.transform.localScale.x < 1)
        {
            offset = new Vector2(-8, 0);
        }
        else
        {
            offset = new Vector2(8, 0);
        }

        distance = Vector2.Distance(player.transform.position, transform.position);

        if (distance > 8)
        {
            //transform.position = player.transform.position + offset;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0.01f);
        }
    }

    //void FixedUpdate()
    //{
    //    RaycastHit hit;
    //    // Does the ray intersect any objects excluding the player layer
    //    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector2.right), out hit, 1))
    //    {
    //        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
    //        Debug.Log("Did Hit");
    //    }
    //    else
    //    {
    //        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1, Color.white);
    //        Debug.Log("Did not Hit");
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            print("Obstacle");
            rb.AddForce(transform.up * jumpForce);
            //other.gameObject.SetActive(false);
        }
    }
}

