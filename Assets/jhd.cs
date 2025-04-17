using UnityEngine;

public class Interaction : MonoBehaviour
{
    void Start()
    {
        // Trouver l'objet par son nom dans la scène
        GameObject robot = GameObject.Find("robot1"); // Remplace "NomDeTonObjet" par le nom réel de ton objet
        if (robot != null)
        {
            // Tu peux maintenant interagir avec l'objet robot
            Debug.Log("Objet trouvé !");
            // Par exemple, tu peux changer sa position
            robot.transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            Debug.Log("Objet non trouvé !");
        }
    }
}
