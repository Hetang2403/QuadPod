using UnityEngine;

public class ChassisStabilizer : MonoBehaviour
{
    public Transform wheelFL;
    public Transform wheelFR;
    public Transform wheelRL;
    public Transform wheelRR;

    public float lerpSpeed = 5f;

    void LateUpdate()
    {
        // Calculate the average plane normal
        Vector3 forward = ((wheelFR.position + wheelRR.position) - (wheelFL.position + wheelRL.position)).normalized;
        Vector3 right = ((wheelFR.position + wheelFL.position) - (wheelRR.position + wheelRL.position)).normalized;
        Vector3 up = Vector3.Cross(forward, right).normalized;

        // Construct a rotation that aligns the chassis to the slope base
        Quaternion targetRotation = Quaternion.LookRotation(forward, up);

        // Smoothly rotate the chassis
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * lerpSpeed);
    }
}
