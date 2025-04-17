using UnityEngine;
using UnityEngine.InputSystem; // Pour le nouveau système d'input

public class ScoreManager : MonoBehaviour
{
    private Score score;
    private Camera mainCamera;
    
    void Awake()
    {
        // Initialiser le Score
        score = new Score();
        
        // Trouver la caméra principale
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Aucune caméra principale trouvée! Assurez-vous d'avoir une caméra avec le tag 'MainCamera'");
        }
        
        Debug.Log("=== DÉMARRAGE DU JEU ===");
        Debug.Log("Score initial: " + score.Value);
    }
    
    void Update()
    {
        // Vérifier si Mouse.current existe
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            HandleClick(Mouse.current.position.ReadValue());
        }
    }
    
    private void HandleClick(Vector2 mousePosition)
    {
        // Vérifier si la caméra existe
        if (mainCamera == null)
        {
            Debug.LogError("Impossible de détecter les clics: pas de caméra principale");
            return;
        }
        
        Debug.Log("--- CLIC DÉTECTÉ ---");
        
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Objet touché: " + hit.collider.gameObject.name);
            
            // Vérifier si score existe
            if (score != null)
            {
                score.Increment();
                Debug.Log("SCORE AUGMENTÉ → Nouveau score: " + score.Value);
            }
            else
            {
                Debug.LogError("L'objet score n'a pas été initialisé!");
            }
        }
        else
        {
            Debug.Log("Aucun objet touché par le rayon");
        }
    }
}