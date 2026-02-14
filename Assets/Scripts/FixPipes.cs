using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class FixPipes : MonoBehaviour
{
    public TilemapRenderer fixedTilemap;
    public GameObject oilDrop;
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (fixedTilemap != null) {
                Debug.Log("Trigger");
                fixedTilemap.enabled = true;
                oilDrop.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        Debug.Log("Triggered by: " + other.name + ", tag: " + other.tag);
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
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
