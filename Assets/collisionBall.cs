using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit by Trigger!");
            Destroy(gameObject);
        }
    }
}