using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionOrTriggerWithTagPlayAnimation : MonoBehaviour 
{
	[SerializeField] private string tagName = "Player";
	[SerializeField] private string animationName;


	private Animator anim;

	private void Awake()
	{
		anim = GetComponent<Animator> ();
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.CompareTag(tagName))
			anim.Play (animationName);

	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.CompareTag(tagName))
			anim.Play (animationName);

	}

}
