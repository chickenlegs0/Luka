using UnityEngine;

/// <summary>
/// Follows the specified object with damping on the directional change
/// </summary>
public class FollowObject : MonoBehaviour
{
    [SerializeField] private Transform objectToFollow;
    [SerializeField] private float followSpeed = 1;
    [SerializeField] private float damping = .1f;

    private Vector2 currentDirection;
    private Rigidbody2D rigidB;

    private void Awake()
    {
        rigidB = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update ()
	{
	    if (objectToFollow == null || rigidB == null)
	        return;

	    Vector2 targetDirection = (Vector2) (objectToFollow.position - transform.position);

	    currentDirection = Vector2.Lerp(currentDirection, targetDirection, Time.deltaTime / damping);

	    rigidB.velocity = currentDirection.normalized * followSpeed;
	}
}
