using UnityEngine;
using System.Collections;

public class PlayerDead : MonoBehaviour
{
    bool isDead = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        if (other.CompareTag("Spike"))
        {
            Debug.Log("Player died by spike.");
            isDead = true;
            DeathCounterManager.Instance.AddDeath();
            StartCoroutine(ResetDeath());
        }
    }

    IEnumerator ResetDeath()
    {
        yield return new WaitForSeconds(0.1f);
        isDead = false;
    }
}
