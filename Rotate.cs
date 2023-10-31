using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Adds rotational velocity onto a GameObject
public class Rotate : MonoBehaviour
{
    // The rotational velocity
    [SerializeField] private float speed = 1f;
    
    // Every interval
    private void Update()
    {
        // Rotate the GameObject by the rotational velocity (accounting for non-fixed updates)
        transform.Rotate(0, 0, speed * Time.deltaTime * 360);
    }
}
