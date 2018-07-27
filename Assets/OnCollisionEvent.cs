using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollisionEvent : MonoBehaviour {

	public string tag = "Player";

	public UnityEvent OnCollision;

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.CompareTag(tag))
			{
				OnCollision.Invoke();
			}
	}
				
}
