using UnityEngine;
using UnityEngine.XR;

public class Quality : MonoBehaviour
{
    void Start()
    {
        OVRManager.fixedFoveatedRenderingLevel = OVRManager.FixedFoveatedRenderingLevel.High;
        if (OVRManager.display != null)
        {
            OVRManager.display.displayFrequency = 72.0f;
        }

        XRSettings.eyeTextureResolutionScale = 1.33f;
        XRSettings.renderViewportScale = 1f;

        QualitySettings.antiAliasing = 4;
    }
}
