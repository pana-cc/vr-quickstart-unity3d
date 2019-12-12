using UnityEngine;
using UnityEngine.XR;

public class TrackedXRDevice : MonoBehaviour
{
    [SerializeField]
    XRNode xrNode;

    // Update is called once per frame
    void Update()
    {
        var device = InputDevices.GetDeviceAtXRNode(this.xrNode);

        device.TryGetFeatureValue(CommonUsages.devicePosition, out var position);
        device.TryGetFeatureValue(CommonUsages.deviceRotation, out var rotation);

        this.transform.localPosition = position;
        this.transform.localRotation = rotation;
    }
}
