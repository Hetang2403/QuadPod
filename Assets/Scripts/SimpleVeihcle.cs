using UnityEngine;

public class SimpleVeihcle : MonoBehaviour
{
    [Header("Wheel Colliders")]
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;

    [Header("Wheel Visuals")]
    public Transform wheelFLVisual;
    public Transform wheelFRVisual;
    public Transform wheelRLVisual;
    public Transform wheelRRVisual;

    [Header("Settings")]
    public float motorTorque = 300f;
    public float maxSteerAngle = 30f;
    public float brakeTorque = 500f;

    private float inputSteer;
    private float inputMotor;
    private float inputBrake;

    void Update()
    {
        inputSteer = Input.GetAxis("Horizontal");
        inputMotor = Input.GetAxis("Vertical");
        inputBrake = Input.GetKey(KeyCode.Space) ? brakeTorque : 0f;
    }

    void FixedUpdate()
    {
        // Apply motor only to REAR wheels
        wheelRL.motorTorque = inputMotor * motorTorque;
        wheelRR.motorTorque = inputMotor * motorTorque;

        // Apply steering only to FRONT wheels
        wheelFL.steerAngle = inputSteer * maxSteerAngle;
        wheelFR.steerAngle = inputSteer * maxSteerAngle;

        // Apply braking to all wheels
        ApplyBrakes(inputBrake);

        // Sync visuals
        UpdateVisuals(wheelFL, wheelFLVisual);
        UpdateVisuals(wheelFR, wheelFRVisual);
        UpdateVisuals(wheelRL, wheelRLVisual);
        UpdateVisuals(wheelRR, wheelRRVisual);
    }

    void ApplyBrakes(float brake)
    {
        wheelFL.brakeTorque = brake;
        wheelFR.brakeTorque = brake;
        wheelRL.brakeTorque = brake;
        wheelRR.brakeTorque = brake;
    }

    void UpdateVisuals(WheelCollider collider, Transform visual)
    {
        Vector3 pos;
        Quaternion rot;
        collider.GetWorldPose(out pos, out rot);
        visual.position = pos;
        visual.rotation = rot;
    }
}
