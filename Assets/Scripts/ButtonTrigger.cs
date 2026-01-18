using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public Door door;
    
    private Vector3 originalScale;
    private bool pressed = false;

    void Start()
    {
        originalScale = transform.localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!pressed && collision.gameObject.CompareTag("Player"))
        {
            pressed = true;

            // vizuelno smanjenje dugmeta
            transform.localScale = new Vector3(
                originalScale.x,
                originalScale.y * 0.5f,
                originalScale.z
            );

            door.OpenDoor();
        }
    }
}
