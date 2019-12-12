using UnityEngine;

public class TrackingSpace : MonoBehaviour
{
    void Start()
    {
        OVRPlugin.SetTrackingOriginType(OVRPlugin.TrackingOrigin.FloorLevel);
    }
}
