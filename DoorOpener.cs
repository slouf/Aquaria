using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DoorOpener : MonoBehaviour
{
    private SpriteRenderer sr;
    private InteractableObject interacted;
    private BoxCollider2D bc;

    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        interacted = GetComponent<InteractableObject>();
        bc = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (interacted.z_Interacted)
        {
            sr.sprite = sprite1;
            bc.isTrigger = true;
            ChangeSize();
        }
        else
        {
            sr.sprite = sprite2;
            bc.isTrigger = false;
            ChangeSize();
        }
    }

    private void ChangeSize()
    {
        if(interacted.z_Interacted)
        {
            bc.size = new Vector2(3f, 1.9f);
        }
        else
        {
            bc.size = new Vector2(0.5f, 1.9f);
        }
    }
}
