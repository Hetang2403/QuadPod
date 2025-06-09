using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public float motorForce = 1500f;
    public float turnTorque = 300f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        rb.AddForce(transform.forward * forwardInput * motorForce);
        rb.AddTorque(Vector3.up * turnInput * turnTorque);
    }
}
