using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
	[SerializeField] private Key[] keysToUnlockThisDoor;
    [SerializeField] private KeyCode keyToPressToUnlock;
    [SerializeField] private UnityEvent OnUnlock;
	[SerializeField] private UnityEvent OnAllKeysEnterRange;

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
        if (coll.GetComponent<RSV.InventoryManager>())
        {
			allKeysAreInRange = true;

			// if they don't have all the keys, then keep allKeysAreInRange false
			foreach (Key k in keysToUnlockThisDoor)
            {
				if (!coll.GetComponent<RSV.InventoryManager>().inventory.Contains(k))
				{
					allKeysAreInRange = false;
				}
            }

			if (allKeysAreInRange)
				OnAllKeysEnterRange.Invoke ();
        }
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.GetComponent<RSV.InventoryManager>())
        {
			// if any of the keys leave then make allKeysAreInRange false
			foreach (Key k in keysToUnlockThisDoor)
			{
				if (coll.GetComponent<RSV.InventoryManager>().inventory.Contains(k))
				{
					allKeysAreInRange = false;
				}
			}
        }
    }
}
