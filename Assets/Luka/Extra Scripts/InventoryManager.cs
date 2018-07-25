using System.Collections.Generic;
using UnityEngine;

namespace RSV
{
    /// <summary>
    /// Manages inventory items 
    ///
    /// Ruben Sanchez
    /// 7/22/18
    /// </summary>
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private Item currentItem;

        [Tooltip("Position to hold items if when they are equipped and visible")]
        [SerializeField] private Transform itemHoldPoint;

        public List<Item> inventory = new List<Item>();

		public KeyCode keyToEquip = KeyCode.E;


		public float pickUpRange = 2;

		private void Update()
		{
			if (Input.GetKeyDown (keyToEquip)) 
			{
				Collider2D[] colls = Physics2D.OverlapCircleAll (transform.position, pickUpRange);

				foreach (Collider2D coll in colls) 
				{
					if (coll.GetComponent<Item> () != null && !inventory.Contains(coll.GetComponent<Item>())) 
					{
						EquipItem(coll.GetComponent<Item>());
					}
				}
			}
		}

        /// <summary>
        /// Use the currently equipped item
        /// </summary>
        public void UseCurrentItem()
        {
            currentItem.Use();
        }

        /// <summary>
        /// Add a new item to the inventory list, parent it to this transform, and set its position to the hold point
        /// </summary>
        /// <param name="newItem">The new item to add to inventory</param>
        public void EquipItem(Item newItem)
        {
            inventory.Add(newItem);

            newItem.transform.SetParent(transform);
            newItem.transform.position = itemHoldPoint.position;
            newItem.transform.eulerAngles = itemHoldPoint.eulerAngles;
            newItem.gameObject.SetActive(false);
        }

        /// <summary>
        /// Cycle on to the next item in inventory and activate it
        /// </summary>
        public void CycleItems()
        {
            currentItem.gameObject.SetActive(false);

            currentItem = inventory[inventory.IndexOf(currentItem) + 1 % inventory.Count];

            currentItem.gameObject.SetActive(true);
        }
    }
}

