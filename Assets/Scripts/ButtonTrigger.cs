using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public Door door;

    private Vector3 originalPosition;
    private bool pressed = false;
    public float pressOffsetY = 0.22f;

    void Start()
    {
        originalPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!pressed && collision.gameObject.CompareTag("Player"))
        {
            pressed = true;

            // Spusti dugme po Y osi
            transform.position = new Vector3(
                originalPosition.x,
                originalPosition.y - pressOffsetY,
                originalPosition.z
            );

            door.OpenDoor();
        }
    }
}
