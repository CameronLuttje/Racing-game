using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRemoteControl3D : MonoBehaviour
{
    [SerializeField]
    private Vector3 targetPositionTransform;
    BasicCarController basicCarController;


    void Awake()
    {
        basicCarController = GetComponent<BasicCarController>();
        SetTarget();
    }


    void FixedUpdate()
    {
        Vector3 targetPosition = targetPositionTransform;
        float forwards = 0;
        float turn = 0;

        Vector3 directionToTarget = (targetPosition - transform.position);
        float dot = Vector3.Dot(transform.forward, directionToTarget);

        float distance = Vector3.Distance(transform.position, targetPosition);
        float minDistance = 1.0f;

        if (distance > minDistance)
        {
            if (dot > 0)
            {
                forwards = 1;
            }
            else if (dot < 0)
            {
                forwards = -1;
            }

            float angle = Vector3.SignedAngle(transform.forward, directionToTarget, Vector3.up);

            if (angle > 5)
            {
                turn = 1;
            }
            else if (angle < -5)
            {
                turn = -1;
            }
        }

        basicCarController.ChangeSpeed(forwards);
        basicCarController.Turn(turn);
    }
    public void SetTarget()
    {
        float rndNum = Random.Range(-1, 1);
        targetPositionTransform = new Vector3(basicCarController.checkPoints[basicCarController.checkPointCounter].transform.position.x + rndNum, basicCarController.checkPoints[basicCarController.checkPointCounter].transform.position.y, basicCarController.checkPoints[basicCarController.checkPointCounter].transform.position.z + rndNum);
    }

}