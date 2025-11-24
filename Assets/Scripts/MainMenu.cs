using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("ScenaIgrice");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit"); // radi samo u Play Mode-u
    }
}
