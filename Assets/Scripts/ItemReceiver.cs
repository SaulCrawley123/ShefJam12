using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Attach this to an object in the PAST scene that the player can use an item on
/// </summary>
public class ItemReceiver : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string objectId;
    [SerializeField] private string requiredItemName;
    [SerializeField] private bool removeItem;
    [SerializeField] private Key useKey = Key.E;

    [Header("Optional: Change sprite in this scene too")]
    [SerializeField] private Sprite changedSprite;

    private bool playerInRange = false;
    private Inventory playerInventory;
    private Keyboard keyboard;
    private SpriteRenderer spriteRenderer;

    public static bool cornWatered = false;

    private void Awake()
    {
        keyboard = Keyboard.current;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (playerInRange && keyboard != null && keyboard[useKey].wasPressedThisFrame)
        {
            if (playerInventory != null && playerInventory.HasItem(requiredItemName))
            {
                if (removeItem)
                {
                    // Remove the item from inventory
                    playerInventory.RemoveItem(requiredItemName);
                }

                // Mark this object as changed globally
                WorldState.SetChanged(objectId);

                if (objectId == "rose")
                {
                    Debug.Log("Watered rose!");
                }
                else if (objectId == "sunflower")
                {
                    Debug.Log("Watered sunflower!");
                }
                else if (objectId == "corn1" || objectId == "corn2" || objectId == "corn3" || objectId == "corn4")
                {
                    cornWatered = true;
                    Debug.Log("Watered corn!");
                }

                // Optionally change sprite in the current scene too
                if (changedSprite != null && spriteRenderer != null)
                {
                    spriteRenderer.sprite = changedSprite;
                }
            }
            else
            {
                Debug.Log("You don't have the required item: " + requiredItemName);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Inventory inventory = other.GetComponent<Inventory>();
        if (inventory != null)
        {
            playerInRange = true;
            playerInventory = inventory;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Inventory>() != null)
        {
            playerInRange = false;
            playerInventory = null;
        }
    }
}