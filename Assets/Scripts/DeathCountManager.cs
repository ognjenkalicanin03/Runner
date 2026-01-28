using UnityEngine;

public class DeathCounterManager : MonoBehaviour
{
    public static DeathCounterManager Instance;
    public int deaths = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddDeath()
    {
        deaths++;
        Debug.Log("Deaths: " + deaths);
    }

    public void ResetDeaths()
    {
        deaths = 0;
    }
}
