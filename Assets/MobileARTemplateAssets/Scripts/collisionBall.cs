using UnityEngine;
using UnityEngine.InputSystem;

public class BulletCollision : MonoBehaviour
{
    public Animator animator;
    public RobotMover robotMover; 
    
    public Score Score;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (Score != null)
            {
                
                Score.Increment();
                Debug.Log("SCORE AUGMENTÉ → Nouveau score: " + Score.GetScore());
            }
            else
            {
                Debug.LogWarning("Score n'est pas assigné.");
            }

            if (animator != null)
            {
                animator.Play("Hit");
            }
            else
            {
                Debug.LogWarning("Animator n'est pas assigné.");
            }

            Destroy(other.gameObject);

            if (robotMover != null)
            {
                robotMover.isDead = true;
            }
            else
            {
                Debug.LogWarning("RobotMover n'est pas assigné.");
            }
        }
    }

    public void Hit()
    {
        gameObject.SetActive(false);
    }
}