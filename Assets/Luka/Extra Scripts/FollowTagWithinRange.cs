using System;
using UnityEngine;

/// <summary>
/// Follows an object with a specified tag if within range
///
/// Ruben Sanchez
/// 7/23/18
/// </summary>
public class FollowTagWithinRange : MonoBehaviour
{
    [SerializeField] private String tagToFollow;

    [Tooltip("This object will begin following if the tagged object is within this range")]
    [SerializeField] private float range = 10;

    [SerializeField] private float followSpeed = .5f;

    [Tooltip("The higher the value, the slower this object will change directions")]
    [SerializeField] private float damping = .2f;

    private Rigidbody2D rigidB;
    private Vector2 currentDirection;
    private Transform objectToFollow;

    void Awake()
    {
        rigidB = GetComponent<Rigidbody2D>();
    }

	void Update ()
	{
	    // if theres currently no target
	    if (objectToFollow == null)
	    {
	        // check if any of the colliders within ranged are tagged as the target tag
	        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);

	        foreach (var col in colliders)
	        {
	            // set target to first collider tagged as the target tag
	            if (col.gameObject.CompareTag(tagToFollow))
	            {
	                objectToFollow = col.transform;
	                break;
	            }
	        }
	    }

	    // there is currently a target
	    else
	    {
	        Vector2 targetDirection = (objectToFollow.position - transform.position).normalized;

	        currentDirection = Vector2.Lerp(currentDirection, targetDirection, Time.deltaTime / damping);

	        rigidB.velocity = currentDirection.normalized * followSpeed;

	        // if the target has is farther than the range, null the target
	        if ((objectToFollow.position - transform.position).magnitude > range)
	            objectToFollow = null;
	    }
    }
}
