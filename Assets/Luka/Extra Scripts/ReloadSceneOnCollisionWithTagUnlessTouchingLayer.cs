using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Reloads scene on collision/trigger with a tag unless this collider is currently touching another collider in a specific layer.
/// </summary>
public class ReloadSceneOnCollisionWithTagUnlessTouchingLayer : MonoBehaviour
{
    [Tooltip("Tag used to reload scene on collision or trigger")]
    [SerializeField] private string tag;

    [Tooltip("Layer used to keep the scene from reloading")]
    [SerializeField] private LayerMask layer;

    private Collider2D collider;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

    // Reload scene on collision with tag unless this collider is touching specified layer
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(tag) && !collider.IsTouchingLayers(layer))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(tag) && !collider.IsTouchingLayers(layer))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Reload scene on trigger with tag unless this collider is touching specified layer
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag(tag) && !collider.IsTouchingLayers(layer))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.CompareTag(tag) && !collider.IsTouchingLayers(layer))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
