using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

// Makes an object oscillate between n points
public class NewBehaviourScript : MonoBehaviour
{
    // Link to a GameObject in the Unity editor
    [SerializeField] private const GameObject[] waypoints;
    
    // Starting index (do not change)
    private int currentWayPointIndex = 0;

    // Time to wait at each waypoint (change in Unity editor)
    [SerializeField] private const int waitTime;
    // Speed to travel to each waypoint (change in Unity editor)
    [SerializeField] private const float speed;

    private void Update()
    {
        // if the GameObject is at the destination
        if (Vector2.Distance(waypoints[currentWayPointIndex].transform.position, transform.position) < .1f)
        {
            // increment (or wrap) the waypoint index
            currentWayPointIndex = currentWayPointIndex++ % waypoints.Length;
        }
        // move the GameObject towards the destination
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWayPointIndex].transform.position, Time.deltaTime * speed);
    }
}
