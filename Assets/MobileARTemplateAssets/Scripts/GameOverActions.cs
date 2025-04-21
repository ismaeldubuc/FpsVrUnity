using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class GameOverActions : MonoBehaviour
{
	void Awake ()
	{
    	DontDestroyOnLoad (this.gameObject);
	}

    public void RestartGame()
    {
        Debug.Log("Reboot game");

        SceneManager.LoadScene("Collision");
    }

    public void QuitGame()
    {
        // Quitte le jeu dans une build
        Debug.Log("Fermuture du jeu...");

        Application.Quit();

#if UNITY_EDITOR
        // Arrête la simulation dans l'éditeur
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}