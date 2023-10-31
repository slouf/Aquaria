using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Class for objects that need to be interacted with
public class InteractableObject : CollidableObject
{

    // Boolean to switch when object is interacted wth
    public bool z_Interacted = false;
    // Method to call other method when the object is interacted with
    protected override void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnInteract();
        }
    }
    // Method called when object is interacted with
    protected virtual void OnInteract()
    {
        z_Interacted = !z_Interacted;
    }
}
