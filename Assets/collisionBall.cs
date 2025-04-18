using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public Animator animator;
    void OnTriggerEnter(Collider other)
    {
        animator.Play("Hit");
        Destroy(other.gameObject);
    }

    public void Hit()
    {
        gameObject.SetActive(false);
    }
}