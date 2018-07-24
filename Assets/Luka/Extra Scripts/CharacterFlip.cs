using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Flips character about its x axis according to velocity or given direction
/// </summary>
public class CharacterFlip : MonoBehaviour
{
    [Tooltip("Transform that will be flipped")]
    [SerializeField] private Transform transformToFlip;

    private Rigidbody2D rigidB;
    private Vector2 originalScale;

    private void Awake()
    {
        rigidB = GetComponent<Rigidbody2D>();
        originalScale = transformToFlip.localScale;
    }

    private void Update()
    {
        // flip character according to the direction of horizontal velocity
        transformToFlip.localScale = rigidB.velocity.x > 0 ? originalScale : new Vector2(-originalScale.x, originalScale.y);
    }

    public void FlipCharacterToDirection(Vector2 direction)
    {
        // flip character according to the given direction
        transformToFlip.localScale = direction.x > 0 ? originalScale : new Vector2(-originalScale.x, originalScale.y);
    }
}
