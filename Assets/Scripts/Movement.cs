using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    Rigidbody2D rb;
    Vector2 move;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // --- HODANJE ---
        move = Vector2.zero;

        if (Keyboard.current.leftArrowKey.isPressed) move.x = -1;
        if (Keyboard.current.rightArrowKey.isPressed) move.x = 1;

        // --- PROVERA DA LI JE NA ZEMLJI ---
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        // --- SKOK ---
        if (Keyboard.current.upArrowKey.wasPressedThisFrame && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // reset brzine
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Kretanje levo-desno uz fiziku
        rb.linearVelocity = new Vector2(move.x * speed, rb.linearVelocity.y);
    }
}
