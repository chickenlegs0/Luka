using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class FlickeringLight : MonoBehaviour 
{
	Light testLight;

	public float minWaitTimeToFlicker = 1f;
	public float maxWaitTimeToFlicker = 4f;

	public float minTimeOff = .2f;
	public float maxTimeOff = .1f;

	private Coroutine flickerCoroutine;


	void Awake () 
	{
		testLight = GetComponent<Light>();
	}

	private void Update()
	{
		if (flickerCoroutine == null)
		{
			flickerCoroutine = StartCoroutine (Flashing ());
		}
	}

	IEnumerator Flashing ()
	{
		yield return new WaitForSeconds (Random.Range (minWaitTimeToFlicker, maxWaitTimeToFlicker));

		testLight.enabled = false;

		yield return new WaitForSeconds (Random.Range (minTimeOff, maxTimeOff));
		
		testLight.enabled = true;

		flickerCoroutine = null;
	}
}