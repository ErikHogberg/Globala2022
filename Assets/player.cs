using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        //Vector3 pos = transform.position;
        //pos.x += x * Time.deltaTime * speed;
        //pos.y += y * Time.deltaTime * speed;
        //transform.position = pos;

        rb.AddForce(new Vector3(x, y, 0)
                .normalized * speed);
    }
}
