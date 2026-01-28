using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public string mainMenuSceneName = "MainMenu";

    void Start()
    {
        pauseMenu.SetActive(false);

        if (SceneManager.GetActiveScene().name == mainMenuSceneName)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        Time.timeScale = pauseMenu.activeSelf ? 0f : 1f;
    }

    public void CloseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
         if (DeathCounterManager.Instance != null)
    {
        DeathCounterManager.Instance.ResetDeaths();
    }
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
