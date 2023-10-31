using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A platform that moves the player along with it
public class StickyPlatform : MonoBehaviour
{

    // When the player touches the platform
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Make the player follow the platform
            collision.gameObject.transform.SetParent(transform);
        }
    }

    // When the player leaves the platform
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Make the player stop following the platform
            collision.gameObject.transform.SetParent(null);
        }
    }

}
