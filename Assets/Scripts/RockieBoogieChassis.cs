using UnityEngine;

public class RockerBogieChassis : MonoBehaviour
{
    public Transform leftAxlePivot;
    public Transform rightAxlePivot;
    public float speed = 3f;

    void Update()
    {
        float leftTilt = NormalizeAngle(leftAxlePivot.localEulerAngles.x);
        float rightTilt = NormalizeAngle(rightAxlePivot.localEulerAngles.x);
        float averageTilt = (leftTilt + rightTilt) / 2f;

        Quaternion target = Quaternion.Euler(averageTilt, 0f, 0f);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * speed);
    }

    float NormalizeAngle(float angle) => (angle > 180f) ? angle - 360f : angle;
}
