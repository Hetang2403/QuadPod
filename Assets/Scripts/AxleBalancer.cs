using UnityEngine;

public class RockerBogieBalancer : MonoBehaviour
{
    public Transform leftAxlePivot;
    public Transform rightAxlePivot;
    public Transform chassis;

    void LateUpdate()
    {
        float leftAngle = leftAxlePivot.localRotation.eulerAngles.z;
        if (leftAngle > 180) leftAngle -= 360;

        float rightAngle = rightAxlePivot.localRotation.eulerAngles.z;
        if (rightAngle > 180) rightAngle -= 360;

        float targetZ = (leftAngle + rightAngle) * 0.5f;
        chassis.localRotation = Quaternion.Euler(0f, 0f, targetZ);
    }
}
