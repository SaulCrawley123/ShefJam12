using UnityEngine;
using UnityEngine.Tilemaps;

public class ChickenFeedCheck : MonoBehaviour
{
    public TilemapRenderer WinDoor;
    public TilemapRenderer Chicken;

 
   
    // Update is called once per frame
    void Update()
    {
        if (FeedChicken.chickensFed)
        {
            WinDoor.enabled = true;
            Chicken.enabled = false;
        }
    }
}
