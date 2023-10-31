using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Light follow player
public class PlayerLight : MonoBehaviour
{
    void Update()
    {
        // Set the transform of light to transform of the parent
        gameObject.transform.SetParent(transform);
    }
}
