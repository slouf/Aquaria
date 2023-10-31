using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for scriptable objects
[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    // Strings and sprites and such
    public string itemName;
    public Sprite icon;
    [TextArea]
    public string description;
}