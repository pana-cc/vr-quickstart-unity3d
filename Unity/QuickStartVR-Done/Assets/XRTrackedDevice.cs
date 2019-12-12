using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRTrackedDevice : MonoBehaviour
{
    [SerializeField]
    private XRNode node;

    // Update is called once per frame
    void Update()
    {
        var device = InputDevices.GetDeviceAtXRNode(this.node);

        device.TryGetFeatureValue(CommonUsages.devicePosition, out var position);
        device.TryGetFeatureValue(CommonUsages.deviceRotation, out var rotation);

        //this.transform.position = position;
        //this.transform.rotation = rotation;

        var rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.MovePosition(position);
        rigidbody.MoveRotation(rotation);
    }
}
