using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    [SerializeField]
    Rigidbody ballBig;

    [SerializeField]
    Rigidbody ballSmall1;

    [SerializeField]
    Rigidbody ballSmall2;

    [SerializeField]
    Rigidbody ballSmall3;

    [SerializeField]
    Collider leftHand;

    [SerializeField]
    Collider rightHand;

    Vector3 ballBigPosition;
    Vector3 ballSmall1Position;
    Vector3 ballSmall2Position;
    Vector3 ballSmall3Position;

    // Start is called before the first frame update
    void Awake()
    {
        this.ballBigPosition = this.ballBig.transform.position;
        this.ballSmall1Position = this.ballSmall1.transform.position;
        this.ballSmall2Position = this.ballSmall2.transform.position;
        this.ballSmall3Position = this.ballSmall3.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == this.leftHand || other == this.rightHand)
        {
            this.ballBig.transform.position = this.ballBigPosition;
            this.ballBig.velocity = Vector3.zero;

            this.ballSmall1.transform.position = this.ballSmall1Position;
            this.ballSmall1.velocity = Vector3.zero;

            this.ballSmall2.transform.position = this.ballSmall2Position;
            this.ballSmall2.velocity = Vector3.zero;

            this.ballSmall3.transform.position = this.ballSmall3Position;
            this.ballSmall3.velocity = Vector3.zero;
        }
    }
}
