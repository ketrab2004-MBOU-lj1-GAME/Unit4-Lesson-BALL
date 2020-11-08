using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody selfRB;
    private Transform player;
    private float destroyHeight = -10f;

    void Start()
    {
        selfRB = GetComponent<Rigidbody>(); //get rigidbody
        player = GameObject.FindWithTag("Player").transform; //find player
    }

    void Update()
    {
        Vector3 lookDirection = (player.position - transform.position).normalized; //get look direction, normalize to change magnitude to 1
        
        selfRB.AddForce(lookDirection * speed);
        //add force in lookdirection with magnitude of speed

        if (transform.position.y <= destroyHeight)
        {
            Destroy(gameObject); //destroy self when below or at destroyHeight
        }
    }
}
