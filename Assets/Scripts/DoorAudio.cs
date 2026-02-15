using UnityEngine;

public class DoorAudio : MonoBehaviour
{
    AudioSource doorOpen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioSource[] sounds = this.GetComponents<AudioSource>();
        doorOpen = sounds[3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DoorOpenSFX()
    {
        doorOpen.Play();
    }
}
