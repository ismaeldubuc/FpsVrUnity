using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingSystem : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootingForce = 500f;
    public float projectileLifetime = 3f;

    [Header("Shooting Settings")]
    public float fireRate = 0.5f;
    private float nextFireTime;

    [Header("Effects")]
    public ParticleSystem muzzleFlash;
    public AudioSource shootSound;

    void Update()
    {
        Debug.Log("Update running...");
        // Vérifie si on peut tirer (basé sur le fireRate)
        if (Time.time >= nextFireTime)
        {
            Debug.Log("Time check passed");
            
            // Utilisation du nouveau Input System pour la souris
            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            {
                Debug.Log("Mouse click detected, calling Shoot()");
                Shoot();
            }
            
            // Utilisation du nouveau Input System pour le touch
            if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
            {
                Debug.Log("Touch detected");
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Debug.Log("Shoot() called");
        // Met à jour le prochain temps de tir possible
        nextFireTime = Time.time + fireRate;

        // Vérifie si les références sont valides
        if (projectilePrefab == null)
        {
            Debug.LogError("Projectile Prefab is missing!");
            return;
        }
        if (firePoint == null)
        {
            Debug.LogError("Fire Point is missing!");
            return;
        }

        // Crée le projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Debug.Log("Projectile instantiated at: " + firePoint.position);
        
        // Applique la force au projectile
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * shootingForce);
            Debug.Log("Force applied to projectile: " + (firePoint.forward * shootingForce));
        }
        else
        {
            Debug.LogError("Rigidbody not found on projectile!");
        }

        // Joue les effets
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }

        if (shootSound != null)
        {
            shootSound.Play();
        }

        // Détruit le projectile après un certain temps
        Destroy(projectile, projectileLifetime);
    }
} 