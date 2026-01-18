using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public AudioSource audioSource;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);   // UBIVA DUPLIKAT
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
