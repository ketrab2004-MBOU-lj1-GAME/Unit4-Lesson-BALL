using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed = 5f;
    public Transform focalPoint;

    private bool hasPowerup = false;
    private float powerupStrength = 15f;

    public GameObject powerupIndicator;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>(); //get rigidbody
        focalPoint = GameObject.Find("FocalPoint").transform; //find focalpoint for camera
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical"); //get forward/downward input
        playerRB.AddForce(focalPoint.forward * speed * forwardInput);
        //add force based on f/d input and speed in the direction of focalpoint
        powerupIndicator.transform.position = transform.position - new Vector3(0,.3f,0);
        //move powerupIndicator onto player but slightly below center
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup")) //if entered trigger with tag powerup
        {
            hasPowerup = true; //has powerup
            powerupIndicator.SetActive(true); //enable powerup indicator
            StartCoroutine(PowerupCountdownRoutine()); //start disable powerup countdown
            Destroy(other.gameObject); //destroy used powerup
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerup) //if collided with enemy tag and has powerup
        {
            Rigidbody otherRB = other.gameObject.GetComponent<Rigidbody>();
            //get other`s rigidbody
            Vector3 awayFPlayer = (other.transform.position - transform.position).normalized;
            //get vector pointing towards enemy, normalize it to a magnitude of 1
            otherRB.AddForce(awayFPlayer * powerupStrength, ForceMode.Impulse);
            //add force to other in awayFPlayer direction, at powerupStrength as an impulse
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7); //wait 7 seconds
        powerupIndicator.SetActive(false); //disable powerupIndicator
        hasPowerup = false; //turn of hasPowerup
    }
}
