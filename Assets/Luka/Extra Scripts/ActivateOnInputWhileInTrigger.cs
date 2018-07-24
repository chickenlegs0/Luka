using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnInputWhileInTrigger : MonoBehaviour {

	public InputManager.InputButton activateButton = InputManager.InputButton.Action1;

	bool activate = false;
	InputManager inputMgr;

	List<Activatable> activatables = new List<Activatable>();

    void OnTriggerEnter2D(Collider2D coll)
    {
        Activatable activatable = coll.gameObject.GetComponent<Activatable>();
        if (activatable != null && !activatables.Contains(activatable)) activatables.Add(activatable);
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        Activatable activatable = coll.gameObject.GetComponent<Activatable>();
        if (activatable != null && activatables.Contains(activatable)) activatables.Remove(activatable);
    }

    void Activate()
	{
		for (int i = 0; i < activatables.Count; i++)
		{
			activatables[i].Activate();
		}
	}

	void Start()
	{
		inputMgr = GameManager.Inst().GetComponent<InputManager>();		
	}

	// Update is called once per frame
	void Update () 
	{
		if (inputMgr.GetKeyDown(activateButton)) Activate();
	}
}
