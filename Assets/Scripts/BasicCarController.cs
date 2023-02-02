using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCarController : MonoBehaviour
{
    [Header("Basic Car Variables")]
    public float maxSpeed = 10f;
    public float turnSpeed = 50f;
    public float accel = 2.5f;
    public float speed = 0f;

    [Header("Ai exclusive")]
    AIRemoteControl3D aiController;

    [Header("Level Variables")]
    //we maken een array; een lijst van gameobjects
    public GameObject[] checkPoints;
    public GameObject currentCheckPoint;
    public int checkPointCounter = 0;
    public Rigidbody rb;
    public List<string> usedCheckPoints = new List<string>(); // hier wordt een list gemaakt genaamt usedCheckPoints

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (this.gameObject.CompareTag("Ai")) // hier wordt gekeken er iets het tag ai heeft
        {
            aiController = GetComponent<AIRemoteControl3D>();
        }
    }
    public void ChangeSpeed(float throttle)
    {
        float forwardSpeed = Vector3.Dot(transform.forward, rb.velocity);
        if (forwardSpeed < maxSpeed && forwardSpeed > -maxSpeed)
        {
            if (throttle != 0)
            {
                speed = speed + accel * throttle * Time.deltaTime;
                speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
            }
            else
            {
                speed = Mathf.Lerp(speed, 0, Time.deltaTime * 3);
            }

            Vector3 velocity = Vector3.forward * speed;
            rb.AddRelativeForce(velocity, ForceMode.Force);
        }

    }

    public void Turn(float direction)
    {

        transform.Rotate(0, direction * turnSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {

        // hij check of je een checkpoint hebt geraakt en dan kijkt hij of je hem al eerder hebt geraakt

        if (other.CompareTag("checkpoints"))
        {
            if (!usedCheckPoints.Contains(other.gameObject.name))
            {

                usedCheckPoints.Add(other.gameObject.name);
                checkPointCounter++;
                if (checkPointCounter > checkPoints.Length - 1)
                {
                    checkPointCounter = 0;
                }
                currentCheckPoint = checkPoints[checkPointCounter];
                if (this.gameObject.CompareTag("Ai"))
                {
                    aiController.SetTarget();
                }

            }
        }

    }
}