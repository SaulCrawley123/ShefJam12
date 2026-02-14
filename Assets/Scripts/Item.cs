using UnityEngine;

/// <summary>
/// Attach this to any pickupable object in the scene.
/// Requires a Collider2D set to "Is Trigger" on the same GameObject.
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class Item : MonoBehaviour
{
    [SerializeField] private InventoryItem itemData;

    public InventoryItem ItemData => itemData;
}