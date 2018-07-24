using UnityEngine;

/// <summary>
/// Manages top down movement
/// </summary>
public class TopDownMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    [Tooltip("The higher the value, the slower the direction changes. Use 0 for instant direction change")]
    [SerializeField] private float damping = .1f;

    private Rigidbody2D rigidB;
    private Vector2 targetDirection;
    private Vector2 currentDirection;

    private void Awake()
    {
        rigidB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        targetDirection = Vector2.zero;

        // get direction based on vertical and horizontal input
        targetDirection += Vector2.right * Input.GetAxisRaw("Horizontal");
        targetDirection += Vector2.up * Input.GetAxisRaw("Vertical");

        // lerp direction with specified damping amount
        currentDirection = Vector2.Lerp(currentDirection, targetDirection, Time.deltaTime / damping);

        rigidB.velocity = currentDirection * moveSpeed;
    }
}
