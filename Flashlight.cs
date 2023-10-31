using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Flashlight : MonoBehaviour
{
    private Vector3 mouse_pos;
    private Transform target;
    private Vector3 object_pos;
    private float angle;

    private void Start()
    {
        target = GetComponent<Transform>();
    }
    private void Update()
    {
        gameObject.transform.SetParent(transform);
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 53.2f;
        object_pos = Camera.main.WorldToScreenPoint(target.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg - 90;
        target.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
