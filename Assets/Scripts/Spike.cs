using UnityEngine;
using UnityEngine.SceneManagement;

public class Bodlja : MonoBehaviour
{

    public float respawnDelay = 0f;

    private Vector3 startPosition;
    private Quaternion startRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        HandleCollision(other.gameObject);
    }

    private void HandleCollision(GameObject other)
    {
        // Ako je bodlja/trougao označen tag-om "Spike" -> respawn
        if (other.CompareTag("Spike"))
        {
            if (respawnDelay <= 0f)
                Respawn();
            else
                Invoke(nameof(Respawn), respawnDelay);
            return;
        }

    if (other.CompareTag("Finish"))
        {
            LoadNextScene();
            return;
        }
       
    }
    private void Respawn()
    {
        // Vrati transform na početno mesto
        transform.position = startPosition;
        transform.rotation = startRotation;

        // Ako imaš Rigidbody/Rigidbody2D, npr. da zaustaviš brzinu:
        var rb2d = GetComponent<Rigidbody2D>();
        if (rb2d != null)
        {
            rb2d.linearVelocity = Vector2.zero;
            rb2d.angularVelocity = 0f;
        }

        var rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // ovde možeš resetovati i animacije, health itd. po potrebi
    }

    private void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        // Ako je poslednja scena, možeš odlučiti: vratiti na 0 ili ostati
        if (nextIndex >= SceneManager.sceneCountInBuildSettings)
        {
            // primer: učitaj prvu scenu (meni) — promeni ponašanje po želji
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(nextIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
