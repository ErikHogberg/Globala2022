using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 10;
    public float SteeringAngle = 20;

    [Space]
    public Rigidbody rb;
    public Transform FrontWheels;
    public Transform RearWheels;

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float gas = Input.GetAxis("Vertical");

        Quaternion steering = Quaternion.identity
            * transform.rotation 
            * Quaternion.AngleAxis(SteeringAngle * x, transform.up)
        ;

        rb.AddForceAtPosition(steering * Vector3.forward * speed * gas, FrontWheels.position);
    }
}
