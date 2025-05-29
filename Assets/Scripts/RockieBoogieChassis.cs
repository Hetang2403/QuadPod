using UnityEngine;

public class RockerBogieChassis : MonoBehaviour
{
    public Transform leftAxle;
    public Transform rightAxle;
    public float speed = 3f;

    void Update()
    {
        float leftTilt = leftAxle.localRotation.eulerAngles.x;
        float rightTilt = rightAxle.localRotation.eulerAngles.x;

        if (leftTilt > 180) leftTilt -= 360;
        if (rightTilt > 180) rightTilt -= 360;

        float average = (leftTilt + rightTilt) / 2f;
        Quaternion target = Quaternion.Euler(average, 0, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * speed);
    }
}
