﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //get left/right input
        transform.Rotate(Vector3.up, -horizontalInput * rotationSpeed * Time.deltaTime);
        //rotate focal point (with camera) based on l/r input, rotSpeed and deltaTime
    }
}
