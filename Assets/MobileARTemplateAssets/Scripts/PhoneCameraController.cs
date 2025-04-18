using UnityEngine;
using UnityEngine.UI;

public class ARCameraBackground : MonoBehaviour
{
    private WebCamTexture webCamTexture;
    public RawImage backgroundImage;
    public AspectRatioFitter aspectFitter;
    
    void Start()
    {
        Input.gyro.enabled = true;
    }
    
    void Update()
    {
        Quaternion deviceRotation = Input.gyro.attitude;
        deviceRotation = Quaternion.Euler(90f, 0f, 0f) * new
            Quaternion(-deviceRotation.x, -deviceRotation.y, deviceRotation.z,
                deviceRotation.w);
        transform.localRotation = deviceRotation;
    }
    
    void OnDisable()
    {
        if (webCamTexture != null && webCamTexture.isPlaying)
        {
            webCamTexture.Stop();
        }
    }
}