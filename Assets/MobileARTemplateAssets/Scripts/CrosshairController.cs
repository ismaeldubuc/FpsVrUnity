using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    public float size = 25f;
    public float thickness = 2f;
    public Color crosshairColor = Color.white;

    void Start()
    {
        // Création du canvas
        GameObject canvasObj = new GameObject("CrosshairCanvas");
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<GraphicRaycaster>();

        // Création du crosshair
        GameObject crosshairObj = new GameObject("Crosshair");
        crosshairObj.transform.SetParent(canvasObj.transform);
        Image crosshairImage = crosshairObj.AddComponent<Image>();
        
        // Configuration du crosshair
        crosshairImage.color = crosshairColor;
        RectTransform rectTransform = crosshairImage.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(thickness, size);
        rectTransform.anchoredPosition = Vector2.zero;

        // Création de la ligne horizontale
        GameObject horizontalLine = new GameObject("HorizontalLine");
        horizontalLine.transform.SetParent(canvasObj.transform);
        Image horizontalImage = horizontalLine.AddComponent<Image>();
        horizontalImage.color = crosshairColor;
        RectTransform horizontalRect = horizontalImage.GetComponent<RectTransform>();
        horizontalRect.sizeDelta = new Vector2(size, thickness);
        horizontalRect.anchoredPosition = Vector2.zero;
    }
} 