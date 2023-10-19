using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Romi.PathTools
{
    public class MoveAlongPath : MonoBehaviour
    {
        [SerializeField] List<PathScript> path;
        [SerializeField] float speed = 2f, rotationSpeed = 5f;
        [SerializeField] LoopMode loopMode;

        [Space(20)]
        [SerializeField] bool useCustomUpVector;
        [SerializeField] Vector3 customUpVector = Vector3.up;

        [Header("Debug")]
        [SerializeField] float distance;
        [SerializeField] float pathLength;

        private float runtimeDistance;
        private float speedDirection = 1f;

        //only for loop mode stop, to stop update from running
        private bool arrived;

        private void Start()
        {
            runtimeDistance = 0f;
        }

        // Update is called once per frame
        private void Update()
        {
            if (arrived)
                return;

            runtimeDistance += speed * speedDirection * Time.deltaTime;

            if (loopMode == LoopMode.PingPong)
            {
                if (runtimeDistance >= path[1].PathDistance || runtimeDistance <= 0f)
                {
                    speedDirection *= -1f;
                }
            }
            else if (loopMode == LoopMode.Stop)
            {
                var adjustedDistance = path[1].PathDistance * 0.999f;

                runtimeDistance = Mathf.Clamp(runtimeDistance, 0f, adjustedDistance);

                if (runtimeDistance >= adjustedDistance)
                    arrived = true;
            }
            else if (loopMode == LoopMode.Loop)
            {
                runtimeDistance %= path[1].PathDistance;
            }

            Debug.Log(runtimeDistance);
            transform.position = path[1].GetPositionAtDistance(runtimeDistance);
            Quaternion targetRot = path[1].GetRotationAtDistance(runtimeDistance, 
                useCustomUpVector ? customUpVector : path[1].GetUpVectorAtDistance(runtimeDistance));
            transform.rotation = Quaternion.Lerp(transform.rotation, 
                targetRot, rotationSpeed * Time.deltaTime);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (!path[1].IsPathReady())
                return;

            transform.position = path[1].GetPositionAtDistance(distance);
            Quaternion targetRot = path[1].GetRotationAtDistance(distance,
                path[1].GetUpVectorAtDistance(distance));
            transform.rotation = targetRot;

            pathLength = path[1].PathDistance;
        }
#endif
    }
}