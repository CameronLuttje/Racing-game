using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AIScript : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float speed = 1f;
    LapSystem LapSystem;
    BasicCarController basicCarController;

    Quaternion targetRot;

    Vector3 target;

    int lastWaypoint = 0;
    private void Awake()
    {
        LapSystem = GetComponent<LapSystem>();
        basicCarController = GetComponent<BasicCarController>();
    }

    private void Update()
    {
        basicCarController.ChangeSpeed(2);
        var currentWaypoint = LapSystem.currentcheckpoint;
        if (currentWaypoint != lastWaypoint)
            {
                target = waypoints[currentWaypoint].position;
                var dir = (target - transform.position).normalized;
                targetRot = Quaternion.LookRotation(dir, Vector3.up);
            }

            lastWaypoint = currentWaypoint;

        
        FacingWaypoint(targetRot);
    }
    public void FacingWaypoint(Quaternion tRot)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, tRot, speed * 2 * Time.deltaTime);
    }
}