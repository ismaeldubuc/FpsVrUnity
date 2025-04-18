using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponPositioner : MonoBehaviour
{
    // Paramètres de positionnement existants
    public Vector3 localPosition = new Vector3(0.05f, -0.58f, 0.65f);
    public Vector3 localRotation = new Vector3(6.957f, -266.425f, 27.33f);
    public float rotationSpeed = 2.0f;
    
    // Nouveaux paramètres pour le tir
    public GameObject bulletPrefab;      // Le préfab du projectile
    public Transform firePoint;          // Le point d'où part le tir
    public float fireRate = 0.5f;        // Tirs par seconde
    public float bulletSpeed = 30f;      // Vitesse du projectile
    
    private float nextFireTime = 0f;     // Pour limiter la cadence de tir
    
    void Start()
    {
        Transform cameraTransform = Camera.main.transform;
        transform.SetParent(cameraTransform);
        transform.localPosition = localPosition;
        transform.localEulerAngles = localRotation;
    }
    
    void Update()
    {
        // Rotation de l'arme avec le nouveau système d'entrée
        float horizontalRotation = 0;
        float verticalRotation = 0;
        
        if (Keyboard.current != null)
        {
            if (Keyboard.current.dKey.isPressed) horizontalRotation = rotationSpeed;
            if (Keyboard.current.aKey.isPressed) horizontalRotation = -rotationSpeed;
            if (Keyboard.current.wKey.isPressed) verticalRotation = rotationSpeed;
            if (Keyboard.current.sKey.isPressed) verticalRotation = -rotationSpeed;
        }
        
        transform.Rotate(Vector3.up, horizontalRotation);
        transform.Rotate(Vector3.left, verticalRotation);
        
        // Gestion du tir
        HandleShooting();
    }
    
    void HandleShooting()
    {
        bool shouldFire = false;
        
        // Détection de l'entrée sur mobile avec le nouveau système d'entrée
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            shouldFire = true;
        }
        
        // Détection de l'entrée sur PC (pour les tests) avec le nouveau système d'entrée
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            shouldFire = true;
        }
        
        // Tir avec limitation de cadence
        if (shouldFire && Time.time >= nextFireTime)
        {
            FireProjectile();
            nextFireTime = Time.time + (1f / fireRate);
        }
    }
    
    void FireProjectile()
    {
        // Vérifier que tout est configuré
        if (bulletPrefab == null)
        {
            Debug.LogWarning("Bullet prefab is not assigned!");
            return;
        }
        
        if (firePoint == null)
        {
            Debug.LogWarning("Fire point is not assigned!");
            return;
        }
        
        // Créer le projectile
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        // Ajouter de la vitesse au projectile
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }
        else
        {
            // Si pas de Rigidbody, utiliser le script Projectile pour définir la direction
            Projectile projectileScript = bullet.GetComponent<Projectile>();
            if (projectileScript != null)
            {
                projectileScript.speed = bulletSpeed;
            }
        }
    }
}