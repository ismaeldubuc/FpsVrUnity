using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public Animator animator;
    public RobotMover robotMover; 
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            animator.Play("Hit");
            Destroy(other.gameObject);
            robotMover.isDead = true;
        }
        else if(other.CompareTag("MainCamera"))
        {
            Hit();
            //tu fait perdre les pv au joueur, parcequ'il a été touché par le robot
        }
        
        
    }

    public void Hit()
    {
        gameObject.SetActive(false);
    }
}