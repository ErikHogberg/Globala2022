using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;

    public Transform FrontWheels;
    public Transform RearWheels;

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float gas = Input.GetAxis("Vertical");

        // rb.AddForce(new Vector3(x, 0, 0)
        //         .normalized * speed);

        rb.AddForceAtPosition(new Vector3(x, 0, 0) * speed, FrontWheels.position);
    }
}
