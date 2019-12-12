using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class GrabbingHand : MonoBehaviour
{
    [SerializeField]
    XRNode xrNode;

    [SerializeField]
    Rigidbody hand;

    [SerializeField]
    Rigidbody grip;

    bool isGrabbing = false;

    Rigidbody capturedObject;

    void Update()
    {
        var device = InputDevices.GetDeviceAtXRNode(this.xrNode);
        device.TryGetFeatureValue(CommonUsages.devicePosition, out var position);
        device.TryGetFeatureValue(CommonUsages.deviceRotation, out var rotation);
        device.TryGetFeatureValue(CommonUsages.gripButton, out var gripButton);

        position = this.transform.parent.TransformPoint(position);
        rotation = this.transform.parent.rotation * rotation;

        if (gripButton && !isGrabbing)
        {
            // Catch
            var nearbyObjects = Physics.OverlapSphere(position, 0.05f);
            var captured = nearbyObjects.FirstOrDefault(o => o.GetComponent<Rigidbody>() != null && o.GetComponent<Rigidbody>().isKinematic == false);
            if (captured)
            {
                this.capturedObject = captured.GetComponent<Rigidbody>();
                this.capturedObject.isKinematic = true;
            }
        }
        else if (!gripButton && isGrabbing)
        {
            // Drop
            if (this.capturedObject != null)
            {
                this.capturedObject.isKinematic = false;
                this.capturedObject = null;
            }
        }

        if (this.capturedObject != null)
        {
            // carry
            this.capturedObject.MovePosition(position + rotation * Vector3.left * (this.xrNode == XRNode.LeftHand ? -0.1f : 0.1f));
            this.capturedObject.MoveRotation(rotation);
        }
        isGrabbing = gripButton;

        if (gripButton)
        {
            this.grip.gameObject.SetActive(true);
            this.grip.MovePosition(position);
            this.grip.MoveRotation(rotation);
            this.hand.gameObject.SetActive(false);
            this.hand.transform.position = position;
            this.hand.transform.rotation = rotation;
        }
        else
        {
            this.grip.gameObject.SetActive(false);
            this.grip.transform.position = position;
            this.grip.transform.rotation = rotation;
            this.hand.gameObject.SetActive(true);
            this.hand.MovePosition(position);
            this.hand.MoveRotation(rotation);
        }
    }
}
