using UnityEngine;

public class AxleVisualizerSync : MonoBehaviour
{
    public Transform physicsPivot;  // assign the real hinge object here

    void LateUpdate()
    {
        if (physicsPivot != null)
        {
            transform.position = physicsPivot.position;
            transform.rotation = physicsPivot.rotation;
        }
    }
}
