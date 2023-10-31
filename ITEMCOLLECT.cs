using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Test class for item collection? (prototype)
public class ITEMCOLLECT : MonoBehaviour
{
    // Grab transform component
    private Transform tr;
    // hitbox
   [SerializeField] private GameObject box;
   // Speed of magnet
    private int speed = 1; 

    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Called when an object enters the boxcollider of object that this script is attached to 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the object colliding is an "item" run statement
        if (collision.gameObject.CompareTag("Item"))
        {
            box.transform.position = Vector2.MoveTowards(box.transform.position, tr.position, speed * Time.deltaTime);
            //Destroy(collision.gameObject);

        }


    }
}
