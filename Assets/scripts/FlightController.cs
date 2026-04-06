// FlightController.cs
// CENG 454 - HW1: Sky-High Prototype
// Author: Mustafa Esad Sarp | Student ID: 200444081

using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = -15f;   
    [SerializeField] private float yawSpeed = 20f;      
    [SerializeField] private float rollSpeed = 20f;     
    [SerializeField] private float thrustSpeed = 25f;  

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        
        float pitchInput = Input.GetAxis("Vertical");
        float pitchAmount = pitchInput * pitchSpeed * Time.deltaTime;

        
        float yawInput = Input.GetAxis("Horizontal");
        float yawAmount = yawInput * yawSpeed * Time.deltaTime;

       
        float rollInput = 0f;
        if (Input.GetKey(KeyCode.Q)) rollInput = 1f;
        if (Input.GetKey(KeyCode.E)) rollInput = -1f;
        float rollAmount = rollInput * rollSpeed * Time.deltaTime;

        
        transform.Rotate(pitchAmount, yawAmount, rollAmount, Space.Self);
        
        
        if (Input.GetKey(KeyCode.Space))
        {
            
            rb.AddRelativeForce(Vector3.forward * thrustSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
    }
}