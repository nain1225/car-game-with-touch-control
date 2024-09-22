using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [Header("Waypoint Status")]
    public Waypoints nextWayPoint;
    public Waypoints previousWaypoint;
    public List<Waypoints> braches = new List<Waypoints>();

    [Range(0f, 1f)]
    public float branchRatio = 0.5f;

    [Range(0f, 5f)]
    public float waypointWidth = 1f;

    public Vector3 GetPosition()
    {
        Vector3 minbound = transform.position + transform.right * waypointWidth / 2f;
        Vector3 maxbound = transform.position - transform.right * waypointWidth / 2f;

        return Vector3.Lerp(minbound, maxbound, Random.Range(0f, 1f));

    }
}
