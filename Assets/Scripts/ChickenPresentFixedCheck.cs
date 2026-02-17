using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class ChickenPresentFixedCheck : MonoBehaviour
{
    public TilemapRenderer chickenFixed;
    public TilemapRenderer chickens;
    public TilemapRenderer winDoor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (FeedChicken.chickensFed)
        {
            chickenFixed.enabled = true;
            chickens.enabled = true;
            winDoor.enabled = true;
        }
    }
}
