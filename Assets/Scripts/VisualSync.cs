using UnityEngine;

public class VisualSync : MonoBehaviour
{
    public Transform visualWheel;
    private WheelCollider wheelCollider;

    void Start() { wheelCollider = GetComponent<WheelCollider>(); }

    void LateUpdate()
    {
        wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        visualWheel.position = pos;
        visualWheel.rotation = rot;
    }
}
