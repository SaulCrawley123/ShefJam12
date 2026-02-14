using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the on-screen inventory display.
/// Attach this to the InventoryPanel GameObject in your Canvas.
/// </summary>
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;

    private List<GameObject> slotInstances = new List<GameObject>();

    /// <summary>
    /// Call this whenever the inventory changes to refresh the display.
    /// </summary>
    public void UpdateUI(List<InventoryItem> items)
    {
        // Clear existing slots
        foreach (var slot in slotInstances)
        {
            Destroy(slot);
        }
        slotInstances.Clear();

        // Create a slot for each item
        foreach (var item in items)
        {
            GameObject slot = Instantiate(slotPrefab, slotParent);
            slotInstances.Add(slot);

            // Set the icon
            Image icon = slot.transform.Find("Icon").GetComponent<Image>();
            if (icon != null && item.icon != null)
            {
                icon.sprite = item.icon;
                icon.enabled = true;
            }
        }
    }
}