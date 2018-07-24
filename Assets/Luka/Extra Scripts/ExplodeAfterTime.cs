using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Explodes after time and sends shrapnel out radially
/// </summary>
public class ExplodeAfterTime : MonoBehaviour
{
    [Tooltip("Objects to shoot out once the object explodes")]
    [SerializeField] private GameObject objectToShootOut;
    [SerializeField] private int numberOfObjectsToShootOut = 5;

    [Tooltip("The amount of time to wait before this object explodes")]
    [SerializeField] private float timeBeforeExplosion = 1;

    [Tooltip("Speed to shoot out the projectiles")]
    [SerializeField] private float projectileShootSpeed = 15;

    [Tooltip("Tag to collide with and begin explosion")]
    [SerializeField] private string TagToCollideWith;

    private float timeToExplode;
    private bool hasExploded;

    private void Start()
    {
        // get target time for explosion
        timeToExplode = Time.time + timeBeforeExplosion;
    }

	// Update is called once per frame
	void Update ()
	{
        // explode once the target time has been reached
	    if (Time.time >= timeToExplode && !hasExploded)
	        Explode();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(TagToCollideWith))
            Explode();
    }

    private void Explode()
    {
        GetComponent<Collider2D>().enabled = false;

        hasExploded = true;

        // begin radially shooting out projectiles, starting with Vector2.right and rotating according to number of projectiles;
        Vector2 direction = transform.right;

        // get angle to rotate by
        float angleTheta = 360f / (float)numberOfObjectsToShootOut;

        for (int i = 0; i < numberOfObjectsToShootOut; i++)
        {
            // instantiate projectile and keep a reference to its rigidbody;
            Rigidbody2D rigidB = Instantiate(objectToShootOut, (Vector2)transform.position + (direction), objectToShootOut.transform.rotation).GetComponent<Rigidbody2D>();

            // rotate direction
            direction = Quaternion.AngleAxis(angleTheta, Vector3.forward) * direction;

            // send projectile in new directions
            rigidB.velocity = direction * projectileShootSpeed;
        }

        Destroy(gameObject);
    }
}
