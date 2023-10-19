using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowsPlayer : MonoBehaviour
{
    public Transform robot;
    private Vector3 camForRobot;

    private void Start()
    {
        camForRobot = robot.position - transform.position;
    }

    private void LateUpdate()
    {
        transform.position = robot.position - robot.rotation * camForRobot;
        transform.LookAt(robot);
    }
}
