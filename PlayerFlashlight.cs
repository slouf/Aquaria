using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Turn on/off flashlight
public class PlayerFlashlight : MonoBehaviour
{
    // Flashlight gameobject, should be a light from unity
    [SerializeField] GameObject flashlight;
    void Update()
    {
        // When F is pressed, turn on/off flashlight
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Turn the opposite of the current status of the flashlight
            flashlight.SetActive(!flashlight.activeInHierarchy);
        }
    }
}
