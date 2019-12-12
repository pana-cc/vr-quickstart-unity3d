using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyXRTrackedDevice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OVRPlugin.SetTrackingOriginType(OVRPlugin.TrackingOrigin.FloorLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
