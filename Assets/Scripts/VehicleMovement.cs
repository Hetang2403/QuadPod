using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public WheelCollider wheelFL, wheelFR, wheelRL, wheelRR;
    public float motorTorque = 200f;
    public float maxSteerAngle = 30f;
    public float brakeForce = 500f;

    void FixedUpdate()
    {
        float motor = Input.GetAxis("Vertical") * motorTorque;
        float steer = Input.GetAxis("Horizontal") * maxSteerAngle;
        bool brake = Input.GetKey(KeyCode.Space);

        wheelFL.steerAngle = steer;
        wheelFR.steerAngle = steer;

        wheelRL.motorTorque = motor;
        wheelRR.motorTorque = motor;

        float brakeTorque = brake ? brakeForce : 0f;
        wheelFL.brakeTorque = brakeTorque;
        wheelFR.brakeTorque = brakeTorque;
        wheelRL.brakeTorque = brakeTorque;
        wheelRR.brakeTorque = brakeTorque;
    }
}
