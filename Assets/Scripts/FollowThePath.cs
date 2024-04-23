using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{

    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed = 2f;

    private int waypointIndex = 0;


    private void Start()
    {
        InitializeWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
        GetComponent<Animator>();

    }

    private void InitializeWaypoints()
    {
        if (gameObject.name.StartsWith("RähinäRiku"))
        {
            InitializeWaypointsRähinä();
        }
        else if (gameObject.name.StartsWith("VIPWoman"))
        {
            InitializeWaypointsVIP();
        }
    }
    private void InitializeWaypointsRähinä()
    {
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = GameObject.Find("RähinäWaypoints (" + i + ")").transform;
        }
    }

    private void InitializeWaypointsVIP()
    {
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = GameObject.Find("VIPWaypoint (" + i + ")").transform;
        }
    }


    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {

            transform.position = Vector3.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);
        }

        /* Debug.Log("waypoints length: " + waypoints.Length.ToString()); */

        if (waypointIndex < waypoints.Length)
        {
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                /* Debug.Log("waypoint index: " + waypointIndex.ToString()); */
                waypointIndex++;
            }
        }

    }


}
