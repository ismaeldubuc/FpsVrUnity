using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverActions : MonoBehaviour
{
    public void RestartGame()
    {

        SceneManager.LoadScene("Game Redirection After Death");
    }

    public void QuitGame()
    {
        // Quitte le jeu dans une build
        Application.Quit();

#if UNITY_EDITOR
        // Arrête la simulation dans l'éditeur
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
