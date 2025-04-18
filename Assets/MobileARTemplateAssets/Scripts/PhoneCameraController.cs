using UnityEngine;
using UnityEngine.UI;

public class PhoneCameraController : MonoBehaviour
{
    private WebCamTexture webCamTexture;
    public RawImage displayImage;
    
    void Start()
    {
        // Vérifier si des caméras sont disponibles
        if (WebCamTexture.devices.Length == 0)
        {
            Debug.Log("Aucune caméra détectée");
            return;
        }
        
        // Utiliser la caméra arrière par défaut (pour la caméra frontale, modifiez l'index)
        webCamTexture = new WebCamTexture(WebCamTexture.devices[0].name, 1280, 720, 30);
        
        // Affecter la texture à l'image UI
        displayImage.texture = webCamTexture;
        
        // Démarrer la caméra
        webCamTexture.Play();
    }
    
    void Update()
    {
        // Si nécessaire, ajustez la rotation selon l'orientation de l'appareil
        if (webCamTexture.isPlaying)
        {
            float scaleY = webCamTexture.videoVerticallyMirrored ? -1f : 1f;
            displayImage.rectTransform.localScale = new Vector3(1f, scaleY, 1f);
            
            int angle = -webCamTexture.videoRotationAngle;
            displayImage.rectTransform.localEulerAngles = new Vector3(0, 0, angle);
        }
    }
    
    void OnDisable()
    {
        if (webCamTexture != null && webCamTexture.isPlaying)
        {
            webCamTexture.Stop();
        }
    }
}