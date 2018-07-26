using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
	[SerializeField] private string[] keysToUnlockThisDoor;
    [SerializeField] private KeyCode keyToPressToUnlock;
    [SerializeField] private UnityEvent OnUnlock;
	[SerializeField] private UnityEvent OnAllKeysEnterRange;
	[SerializeField] private string tagThatHoldsTheyKeys = "Player";

	private bool allKeysAreInRange;

    private void Update()
    {

        if(Input.GetKeyDown(keyToPressToUnlock) && allKeysAreInRange)
            OnUnlock.Invoke();
    }

    public void Unlock()
    {
        OnUnlock.Invoke();
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
		if (coll.CompareTag(tagThatHoldsTheyKeys))
        {
			allKeysAreInRange = true;

			InventoryManager inventoryManager = GameObject.FindObjectOfType<InventoryManager> ();

			if (inventoryManager)
			{
				// if they don't have all the keys, then keep allKeysAreInRange false
				foreach (string k in keysToUnlockThisDoor)
				{
					if (!inventoryManager.Inventory.ContainsKey(k))
					{
						allKeysAreInRange = false;
					}
				}

				if (allKeysAreInRange)
					OnAllKeysEnterRange.Invoke ();
			}

		
        }
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
		if (coll.CompareTag(tagThatHoldsTheyKeys))
        {

			InventoryManager inventoryManager = GameObject.FindObjectOfType<InventoryManager> ();

			if (inventoryManager) {

				// if any of the keys leave then make allKeysAreInRange false
				foreach (string k in keysToUnlockThisDoor)
				{
					if (inventoryManager.Inventory.ContainsKey(k))
					{
						allKeysAreInRange = false;
					}
				}
			}
		
        }
    }
}
