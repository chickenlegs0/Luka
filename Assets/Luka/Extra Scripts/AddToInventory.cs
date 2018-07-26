using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToInventory : MonoBehaviour
{
    [SerializeField] private string itemToAdd;
    [SerializeField] private int amountToAdd;

    private InventoryManager inventoryManager;

    public void AddInventory()
    {
        inventoryManager = GameObject.FindObjectOfType<InventoryManager>();

        if(inventoryManager)
            inventoryManager.AddInventory(itemToAdd, amountToAdd);
    }
}
