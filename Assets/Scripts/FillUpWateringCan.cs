using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Fills up the empty watering can using the purified coral water
/// </summary>
public class FillUpWateringCan : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string requiredItemName;
    [SerializeField] private string receivedItemName;
    [SerializeField] private Key useKey = Key.E;

    private bool playerInRange = false;
    private bool hasBeenUsed = false;
    private Inventory playerInventory;
    private Keyboard keyboard;

    void Awake()
    {
        keyboard = Keyboard.current;
    }

    void Update() {

        if (hasBeenUsed)
        {
            Debug.Log("You have already done that!");
            return;
        }

        if (FixPipes.coralFixed)
        {
            if (playerInRange && keyboard != null && keyboard[useKey].wasPressedThisFrame)
            {
                if (playerInventory.HasItem(requiredItemName))
                {
                    // Remove the item from inventory
                    playerInventory.RemoveItem(requiredItemName);

                    // Give new item
                    playerInventory.AddItem(receivedItemName);

                    hasBeenUsed = true;

                    Debug.Log("Filled the watering can!");

                }
                else
                {
                    Debug.Log("You don't have the required item: " + requiredItemName);
                }
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

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Inventory>() != null)
        {
            playerInRange = false;
            playerInventory = null;
        }
    }
}