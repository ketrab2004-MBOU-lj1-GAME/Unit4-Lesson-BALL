using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float rotateSpeed = 2f;
    void Update()
    {
        transform.RotateAround(Vector3.up, rotateSpeed * Time.deltaTime); //rotate around up axis at rotateSpeed and deltatime
        //for powerupIndicator and powerups
    }
}
