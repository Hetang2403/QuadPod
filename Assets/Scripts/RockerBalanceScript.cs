using UnityEngine;

public class RockerAxleController : MonoBehaviour
{
    public Transform frontWheel;
    public Transform rearWheel;
    public float speed = 5f;
    public float maxTilt = 30f;

    void Update()
    {
        float frontY = GetGroundY(frontWheel.position);
        float rearY = GetGroundY(rearWheel.position);
        float diff = frontY - rearY;

        float dist = Vector3.Distance(frontWheel.position, rearWheel.position);
        if (dist == 0) return;

        float angle = Mathf.Clamp(Mathf.Atan2(diff, dist) * Mathf.Rad2Deg, -maxTilt, maxTilt);
        Quaternion target = Quaternion.Euler(angle, 0, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * speed);
    }

    float GetGroundY(Vector3 pos)
    {
        if (Physics.Raycast(pos + Vector3.up, Vector3.down, out RaycastHit hit, 5f))
            return hit.point.y;
        return pos.y;
    }
}
