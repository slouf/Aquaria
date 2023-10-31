using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
   
    // Called when object enters box collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            // Item gets destroyed when it comes in contact with original object
            Destroy(collision.gameObject);
           
        }
    }
}
