using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float speed = 10;
    public float SteeringAngle = 20;

    [Space]
    public Rigidbody rb;
    public Transform FrontWheels;
    public Transform RearWheels;
    public Transform CenterOfGravity;

    [Space]
    public Timer timer;


    private void Start()
    {
        rb.centerOfMass = CenterOfGravity.localPosition;
    }

    bool paused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // restart-knapp
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
            paused = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape)) // paus-knapp
        {
            paused = !paused;
        }
        if (!paused && Input.GetKey(KeyCode.Space)) // slow-motion knapp
        {
            Time.timeScale = 0.5f;
        }
        else if (!paused && Input.GetKey(KeyCode.LeftShift)) // speed-up knapp
        {
            Time.timeScale = 2f;
        }
        else
        {
            if (paused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    void FixedUpdate()
    {

        if (!touchingGround) return; // kom ihåg utropstecken (betyder "not" och inverterar true/false)

        // hämtar input från tangentbord
        float x = Input.GetAxis("Horizontal"); // A och D, vänster och höger
        float y = Input.GetAxis("Vertical"); // W och S, upp och ned
        float gas = Input.GetAxis("Vertical"); // samma som y

        // räkna ut rotation för styrning
        Quaternion steering = Quaternion.identity // utgå från inget/tomt
            * transform.rotation // lägg till vart bilen pekar nu
            * Quaternion.AngleAxis(SteeringAngle * x, transform.up) // lägg till styrvinkel runt upp-axel
        ;

        rb.AddForceAtPosition(
            steering * Vector3.forward * speed * gas,
            FrontWheels.position
        );
    }
    bool touchingGround = false;

    void OnCollisionStay(Collision other)
    {
        touchingGround = true;
    }

    private void OnCollisionExit(Collision other)
    {
        touchingGround = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        { // Kollar om man gick i mål
            Debug.Log("Win"); // skriver att man vann
            timer.on = false; // stänger av timern
        }
    }
}
