using System.Collections;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public float timeBeforeDisappear = 1f;
    public float timeToRespawn = 3f;

    private SpriteRenderer sr;
    private Collider2D col;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Disappear());
        }
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(timeBeforeDisappear);

        sr.enabled = false;
        col.enabled = false;

        yield return new WaitForSeconds(timeToRespawn);

        sr.enabled = true;
        col.enabled = true;
    }
}
