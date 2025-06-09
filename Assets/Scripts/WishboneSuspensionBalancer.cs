using UnityEngine;

public class WishboneSuspensionBalancer : MonoBehaviour
{
    [Header("Wheel Colliders (Left Side)")]
    public Transform wheelFL;
    public Transform wheelRL;

    [Header("Wheel Colliders (Right Side)")]
    public Transform wheelFR;
    public Transform wheelRR;

    [Header("Axle Pivots")]
    public Transform leftAxlePivot;
    public Transform rightAxlePivot;

    [Header("Balancing Settings")]
    public float springStrength = 8000f;
    public float damperStrength = 450f;
    public float maxExtension = 0.5f;
    public float stabilizerForce = 2000f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        ApplySuspension(wheelFL.position, leftAxlePivot.position);
        ApplySuspension(wheelRL.position, leftAxlePivot.position);
        ApplySuspension(wheelFR.position, rightAxlePivot.position);
        ApplySuspension(wheelRR.position, rightAxlePivot.position);

        ApplyStabilizer(wheelFL.position, wheelFR.position);
        ApplyStabilizer(wheelRL.position, wheelRR.position);
    }

    void ApplySuspension(Vector3 wheelPos, Vector3 pivot)
    {
        RaycastHit hit;
        Vector3 direction = -transform.up;

        if (Physics.Raycast(wheelPos, direction, out hit, maxExtension))
        {
            float compression = maxExtension - hit.distance;
            Vector3 force = direction * compression * springStrength;
            rb.AddForceAtPosition(force, pivot);
        }
    }

    void ApplyStabilizer(Vector3 left, Vector3 right)
    {
        float leftDistance = GetGroundDistance(left);
        float rightDistance = GetGroundDistance(right);
        float difference = leftDistance - rightDistance;

        Vector3 forceDir = transform.up * difference * stabilizerForce;
        rb.AddForceAtPosition(forceDir, left);
        rb.AddForceAtPosition(-forceDir, right);
    }

    float GetGroundDistance(Vector3 pos)
    {
        if (Physics.Raycast(pos, -transform.up, out RaycastHit hit, maxExtension))
            return hit.distance;
        else
            return maxExtension;
    }
}
