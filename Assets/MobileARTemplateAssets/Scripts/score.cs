using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;


public class Score : MonoBehaviour
{
    [SerializeField] private int value = 0;
	[SerializeField] private TextMeshProUGUI scoreText;
    
    public int Value => value;

	private void Start()
    {
        UpdateScoreDisplay();
    }

    public void Increment() 
    { 
        value++;
        UpdateScoreDisplay();
    }

    public void Decrement() 
    { 
        if (value > 0) 
            value--;
        UpdateScoreDisplay();
    }

    public int GetScore() => value;

    private void UpdateScoreDisplay()
    {
		if (scoreText == null)
        {
            Debug.LogWarning("scoreText n'est pas assigné !");
            return;
        }
        scoreText.text = "Score : " + value;
    }
}