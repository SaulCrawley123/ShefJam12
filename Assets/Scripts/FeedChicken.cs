using NUnit.Framework;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class FeedChicken : MonoBehaviour
{
    private bool playerInRange = false;
    public static bool chickensFed = false;

    private Inventory playerInventory;

    void Update()
    {
        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (playerInventory != null && playerInventory.HasItem("Corn"))
            {
                Debug.Log("Trigger");
                chickensFed = true;
                playerInventory.RemoveItem("Corn");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Inventory inventory = other.GetComponent<Inventory>();

        Debug.Log("Triggered by: " + other.name + ", tag: " + other.tag);
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerInventory = inventory;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
