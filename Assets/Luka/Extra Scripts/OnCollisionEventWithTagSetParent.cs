using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets this transforms parent to collided object on collision or trigger with specific tag
/// Unparents on OnCollisionExit/OnTriggerExit
/// </summary>
public class OnCollisionEventWithTagSetParent : MonoBehaviour
{
    [Tooltip("Tag used to set the parent of this transform ")]
    [SerializeField] private string tag;

    // Set parent on collision with specified tag
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(tag))
            transform.SetParent(coll.transform);
    }

    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(tag))
            transform.SetParent(coll.transform);
    }

    // Unparent on Collision exit if currently parented to the collider
    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(tag) && transform.parent == coll.transform)
            transform.SetParent(null);
    }

    // Set parent on trigger with specified tag
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag(tag))
            transform.SetParent(coll.transform);
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.CompareTag(tag))
            transform.SetParent(coll.transform);
    }

    // Unparent on trigger exit if currently parented to the collider
    private void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.CompareTag(tag) && transform.parent == coll.transform)
            transform.SetParent(null);
    }
}
