using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    public AudioSource deathSound;
    bool isDead = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        if (other.CompareTag("Spike"))
        {
            DeathCounterManager.Instance.AddDeath();
            isDead = true;
            //deathSound.Play();
            // ovde ide tvoja logika smrti:
            // npr. restart levela, animacija, disable kontrole...
        }
    }
}
