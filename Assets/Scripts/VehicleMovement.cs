using UnityEngine;
public class VehicleMovement : MonoBehaviour
{

    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;

    public float motorTorque = 200f;
    public float maxSteerAngle = 30f;
    public float brakeForce = 500f;

    private float inputVertical;
    private float inputHorizontal;
    private bool isBraking;

    void Update()
    {
        inputVertical = Input.GetAxis("Vertical");
        inputHorizontal = Input.GetAxis("Horizontal");
        isBraking = Input.GetKey(KeyCode.Space);
    }

    void FixedUpdate()
    {
        // Steering (Front Wheels)
        wheelFL.steerAngle = maxSteerAngle * inputHorizontal;
        wheelFR.steerAngle = maxSteerAngle * inputHorizontal;

        // Drive (Rear Wheels)
        wheelRL.motorTorque = inputVertical * motorTorque;
        wheelRR.motorTorque = inputVertical * motorTorque;

        // Braking
        float brake = isBraking ? brakeForce : 0f;
        wheelFL.brakeTorque = brake;
        wheelFR.brakeTorque = brake;
        wheelRL.brakeTorque = brake;
        wheelRR.brakeTorque = brake;
    }
}
