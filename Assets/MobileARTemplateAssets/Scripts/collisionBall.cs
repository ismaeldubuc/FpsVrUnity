using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public Animator animator;
    public RobotMover robotMover; 
    
    public Score Score;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Bullet"))
        {
            Debug.Log("SCORE AUGMENTÉ → Nouveau score: " + Score.GetScore());
            animator.Play("Hit");
            Destroy(other.gameObject);
            robotMover.isDead = true;
            Score.Increment();
        }
        else if(other.CompareTag("MainCamera"))
        {
            Hit();
            if (Score.GetScore() == 0)
            {
                Debug.Log("game over");
                // game over
            }
            else
            {
                Score.Decrement();
                Debug.Log("SCORE REDUIT → Nouveau score: " + Score.GetScore());
            }
            //tu fait perdre les pv au joueur, parcequ'il a été touché par le robot
        }
        
        
    }

    public void Hit()
    {
        gameObject.SetActive(false);
    }
}