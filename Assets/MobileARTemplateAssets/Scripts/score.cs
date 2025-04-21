using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int value = 10;
    
    public int Value => value;

    public void Increment() => value++;
    public void Decrement() { if (value > 0) value--; }
    public int GetScore() => value;
}