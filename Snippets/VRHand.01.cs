using UnityEngine;
using UnityEngine.XR;

public class XRHand : MonoBehaviour
{
    [SerializeField]
    XRNode xrNode;

    [SerializeField]
    Rigidbody hand;

    // Update is called once per frame
    void Update()
    {
        var device = InputDevices.GetDeviceAtXRNode(this.xrNode);

        device.TryGetFeatureValue(CommonUsages.devicePosition, out var position);
        device.TryGetFeatureValue(CommonUsages.deviceRotation, out var rotation);

        //this.transform.localPosition = position;
        //this.transform.localRotation = rotation;

        position = this.transform.parent.TransformPoint(position);
        rotation = this.transform.parent.rotation * rotation;

        this.hand.MovePosition(position);
        this.hand.MoveRotation(rotation);
    }
}
