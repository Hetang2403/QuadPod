using UnityEngine;

public class WheelVisualSync : MonoBehaviour
{
    public Transform visualWheel;

    private WheelCollider wheelCollider;

    void Start()
    {
        wheelCollider = GetComponent<WheelCollider>();
    }

    void Update()
    {
        if (visualWheel == null || wheelCollider == null) return;

        wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        visualWheel.position = pos;
        visualWheel.rotation = rot;
    }
}
