using UnityEngine;

public class WishboneVisualizer : MonoBehaviour
{
    public Transform wheelFront;
    public Transform wheelRear;
    public Transform chassisPivot;

    [ContextMenu("Generate Wishbone Arm")]
    void GenerateWishboneArm()
    {
        CreateVisualArm(chassisPivot, wheelFront, "Arm_Front");
        CreateVisualArm(chassisPivot, wheelRear, "Arm_Rear");
    }

    void CreateVisualArm(Transform start, Transform end, string name)
    {
        GameObject arm = GameObject.CreatePrimitive(PrimitiveType.Cube);
        arm.name = name;
        arm.transform.SetParent(this.transform);

        Vector3 mid = (start.position + end.position) / 2f;
        arm.transform.position = mid;

        Vector3 direction = end.position - start.position;
        arm.transform.rotation = Quaternion.LookRotation(direction);
        arm.transform.localScale = new Vector3(0.05f, 0.05f, direction.magnitude);
    }
}
