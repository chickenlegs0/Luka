using UnityEngine;

/// <summary>
/// Switches a rigidbody to kinematic if collides with a certain tag, resets on collision exit
/// </summary>
public class BecomeKinematicOnCollisionWithTag : MonoBehaviour
{
    [SerializeField] private string tag;

    private Rigidbody2D rigidB;

    private void Awake()
    {
        rigidB = GetComponent<Rigidbody2D>();
    }

    // become kinematic on collision with tag
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(tag))
        {
            rigidB.isKinematic = true;
            rigidB.velocity = Vector2.zero;
            rigidB.angularVelocity = 0;
        }
    }

    // rest to dynamic on collision exit with tag
    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(tag))
            rigidB.isKinematic = false;
    }
}
