using UnityEngine;
using UnityEngine.InputSystem;  
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string sceneToLoad;
    private bool playerInRange = false;
    public Vector2 targetSpawnPosition;

    GameObject player;
    AudioSource doorOpen;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        AudioSource[] sounds = player.GetComponents<AudioSource>();
        doorOpen = sounds[3];
    }

    void Update()
    {
        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            SpawnManager.spawnPosition = targetSpawnPosition;
            SceneManager.LoadScene(sceneToLoad);
            SpawnManager.hasSpawnPosition = true;
            doorOpen.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
