using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class ScoreManager : MonoBehaviour
{
    private Score score;
    private Camera mainCamera;
    private TextMeshProUGUI scoreText;

    void Awake()
    {
        score = new Score();
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Aucune caméra principale trouvée! Assurez-vous d'avoir une caméra avec le tag 'MainCamera'");
        }

        GameObject scoreObj = GameObject.FindGameObjectWithTag("score_txt");
        if (scoreObj != null)
        {
            scoreText = scoreObj.GetComponent<TextMeshProUGUI>();
            UpdateScoreText(); // Affiche "Score : 0" au départ
        }
        else
        {
            Debug.LogError("Aucun objet avec le tag 'score_txt' trouvé !");
        }

        Debug.Log("=== DÉMARRAGE DU JEU ===");
        Debug.Log("Score initial: " + score.Value);
    }

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            HandleClick(Mouse.current.position.ReadValue());
        }
    }

    private void HandleClick(Vector2 mousePosition)
    {
        if (mainCamera == null)
        {
            Debug.LogError("Impossible de détecter les clics: pas de caméra principale");
            return;
        }

        Debug.Log("--- CLIC DÉTECTÉ ---");

        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log("Objet touché: " + hit.collider.gameObject.name);

            if (score != null)
            {
                score.Increment();
                Debug.Log("SCORE AUGMENTÉ → Nouveau score: " + score.Value);
                UpdateScoreText(); // Met à jour le texte visible
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

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score : " + score.Value;
        }
    }
}
