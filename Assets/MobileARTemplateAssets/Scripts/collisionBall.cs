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
            Score.Increment();
            Debug.Log("SCORE AUGMENTÉ → Nouveau score: " + Score.GetScore());
            animator.Play("Hit");
            Destroy(other.gameObject);
            robotMover.isDead = true;
        }
        else 
        {
            Score.Decrement();
            Debug.Log("SCORE REDUIT → Nouveau score: " + Score.GetScore());
        }
    }

    public void Hit()
    {
        gameObject.SetActive(false);
    }
}