using UnityEngine;

public class RockerAxleBalancer : MonoBehaviour
{
    public Transform frontHelper;
    public Transform rearHelper;
    public float rotationSpeed = 5f;
    public float maxTilt = 30f;

    void FixedUpdate()
    {
        float frontY = GetTerrainHeight(frontHelper.position);
        float rearY = GetTerrainHeight(rearHelper.position);

        float deltaY = frontY - rearY;
        float distance = Vector3.Distance(frontHelper.position, rearHelper.position);
        if (distance == 0) return;

        float angle = Mathf.Clamp(Mathf.Atan2(deltaY, distance) * Mathf.Rad2Deg, -maxTilt, maxTilt);
        Quaternion targetRotation = Quaternion.Euler(angle, 0f, 0f);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);
    }

    float GetTerrainHeight(Vector3 pos)
    {
        if (Physics.Raycast(pos + Vector3.up, Vector3.down, out RaycastHit hit, 10f))
            return hit.point.y;
        return pos.y;
    }
}
