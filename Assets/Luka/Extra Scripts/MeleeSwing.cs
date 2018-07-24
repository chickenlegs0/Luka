using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Plays an animation that uses the Swing method as an event which Circle Casts for enemies
/// </summary>
public class MeleeSwing : MonoBehaviour
{
    [Tooltip("Position to cast for enemies")]
    [SerializeField] private Transform hitPoint;

    [Tooltip("Radius from the hit point to detect enemies")]
    [SerializeField] private float attackRadiusFromPoint;

    [SerializeField] private float attackDamage;

    [SerializeField] private KeyCode attackKey;
    [SerializeField] private string attackAnimationName = "Swing";

    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        // Swing on Input
        if(Input.GetKeyDown(attackKey))
            Swing();
    }

    public void Swing()
    {
        // Play swing animation
        anim.Play(attackAnimationName);
    }

    public void AttackEnemies()
    {
        // Get all enemies within the specified radius
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(hitPoint.position, attackRadiusFromPoint);

        // Damage enemies within the radius
        foreach (var coll in enemiesHit)
        {
            if(coll.gameObject.GetComponent<HealthManager>() != null)
                coll.gameObject.GetComponent<HealthManager>().TakeDamage(attackDamage); 
        }
    }
}
