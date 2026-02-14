using UnityEngine;

/// <summary>
/// ScriptableObject that defines an item type.
/// Create new items in the Project panel: Right-click → Inventory → New Item.
/// </summary>
[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/New Item")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    [TextArea] public string description;
}