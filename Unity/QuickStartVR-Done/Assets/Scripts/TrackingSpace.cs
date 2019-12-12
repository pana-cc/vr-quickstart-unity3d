using UnityEngine;

public class TrackingSpace : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OVRPlugin.SetTrackingOriginType(OVRPlugin.TrackingOrigin.FloorLevel);
    }
}
