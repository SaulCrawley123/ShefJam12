using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

/// <summary>
/// Attach this to the Player object.
/// Handles picking up items and notifying the UI.
/// </summary>
public class Inventory : MonoBehaviour
{
    [SerializeField] private int maxSlots = 8;
    [SerializeField] private InventoryUI inventoryUI;

    private List<InventoryItem> items = new List<InventoryItem>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Try to get the Item component from whatever we touched
        Item item = other.GetComponent<Item>();

        if (item != null && items.Count < maxSlots)
        {
            items.Add(item.ItemData);
            Debug.Log("Picked up: " + item.ItemData.itemName);

            // Update the on-screen inventory display
            if (inventoryUI != null)
            {
                inventoryUI.UpdateUI(items);
            }

            // Remove the item from the scene
            Destroy(other.gameObject);
        }
    }

    public List<InventoryItem> GetItems() => items;

    public bool HasItem(string itemName) => items.Exists(i => i.itemName == itemName);

    public void RemoveItem(string itemName)
    {
        InventoryItem found = items.Find(i => i.itemName == itemName);
        if (found != null)
        {
            items.Remove(found);
            inventoryUI?.UpdateUI(items);
        }
    }
}