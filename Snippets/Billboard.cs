using UnityEngine;

public class Billboard : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // this.transform.LookAt(Camera.main.transform.position);
        this.transform.rotation = Quaternion.LookRotation(this.transform.position - Camera.main.transform.position, Vector3.up);
    }
}
