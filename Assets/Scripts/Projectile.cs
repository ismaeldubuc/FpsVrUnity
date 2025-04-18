using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 30f;
    public float lifetime = 3f;
    public int damage = 1;
    public GameObject hitEffect; // Facultatif, pour l'effet d'impact

    void Start()
    {
        // Détruire le projectile après un certain temps
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Vérifier si on a touché une cible
        /*TargetBehavior target = other.GetComponent<TargetBehavior>();
        if (target != null)
        {
            target.TakeDamage(damage);
        }

        // Créer un effet d'impact si défini
        if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }*/

        // Détruire le projectile quand il touche quelque chose
        Destroy(gameObject);
    }
}