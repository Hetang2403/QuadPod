using UnityEngine;

public class AxleBalancer : MonoBehaviour
{
    public Transform wheelFront;
    public Transform wheelRear;
    public Transform axleTransform;    // this GameObject
    public Rigidbody chassisRb;

    public float stiffness = 1000f;
    public float damping = 150f;

    private float lastDelta;

    void FixedUpdate()
    {
        float deltaY = wheelFront.position.y - wheelRear.position.y;

        float velocity = (deltaY - lastDelta) / Time.fixedDeltaTime;
        float torque = (deltaY * stiffness) - (velocity * damping);

        Vector3 torqueVector = transform.forward * torque; // axle tilts on forward axis
        chassisRb.AddTorque(torqueVector);

        lastDelta = deltaY;
    }
}
