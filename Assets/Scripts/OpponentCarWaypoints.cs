using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCarWaypoints : MonoBehaviour
{

    [Header("Car Ai")]
    public OpponentCar car;
    public Waypoints currentWaypoint;

    private void Awake()
    {
        car = GetComponent<OpponentCar>();

    }
    private void Start()
    {
        car.locateDestination(currentWaypoint.GetPosition());

    }
    private void Update()
    {
        if (car.destinationReached)
        {
            currentWaypoint = currentWaypoint.nextWayPoint;
            car.locateDestination(currentWaypoint.GetPosition());

        }
    }
}
