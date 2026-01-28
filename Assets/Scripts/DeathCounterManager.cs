using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCounterManager : MonoBehaviour
{
    public static DeathCounterManager Instance;

    public int deathCount = 0;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // svaki put kad se učita Main Menu → reset
        if (scene.name == "MainMenu")
        {
            ResetDeaths();
        }
    }

    public void AddDeath()
    {
        deathCount++;
    }

    public void ResetDeaths()
    {
        deathCount = 0;
    }
}
