using UnityEngine;

public class RockerBogieBalancer : MonoBehaviour
{
    public Transform leftAxlePivot;
    public Transform rightAxlePivot;

    void LateUpdate()
    {
        Vector3 forward = Vector3.Cross(rightAxlePivot.position - leftAxlePivot.position, transform.right);
        transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
    }
}
