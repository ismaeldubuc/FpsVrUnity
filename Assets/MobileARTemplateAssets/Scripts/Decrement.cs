using UnityEngine;
using TMPro;  // Pour utiliser TextMeshPro
using UnityEngine.InputSystem;

public class LifeManager : MonoBehaviour
{
    private int life = 10;  // Initialement 10 vies
    private TextMeshProUGUI lifeText;

    void Awake()
    {
        // Trouver l'objet avec le tag 'life_tag'
        GameObject lifeObj = GameObject.FindGameObjectWithTag("life_tag");
        
        if (lifeObj != null)
        {
            lifeText = lifeObj.GetComponent<TextMeshProUGUI>();
            UpdateLifeText(); // Affiche la vie initiale
        }
        else
        {
            Debug.LogError("Aucun objet avec le tag 'life_tag' trouvé !");
        }
    }

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Décrémenter la vie à chaque clic
            DecreaseLife();
        }
    }

    private void DecreaseLife()
    {
        if (life > 0)
        {
            life--;  // Décrémenter la vie de 1
            Debug.Log("VIE DÉCRÉMENTÉE → Nouvelle vie: " + life);
            UpdateLifeText(); // Mettre à jour le texte avec la nouvelle vie
        }
        else
        {
            Debug.Log("Aucune vie restante !");
        }
    }

    private void UpdateLifeText()
    {
        if (lifeText != null)
        {
            lifeText.text = "Vie : " + life;
        }
    }
}
