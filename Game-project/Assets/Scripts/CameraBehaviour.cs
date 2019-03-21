using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform target;            // The position that that camera will be following.
    public float smoothing = 5f;        // The speed with which the camera will be following.

    Vector3 offset;                     // The initial offset from the target.

    Quaternion angle;

    void Start ()
    {
        // Calculate the initial offset.
        offset = transform.position - target.position;

        angle = transform.rotation;
    }

    void FixedUpdate ()
    {
        // Create a postion the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = target.position + offset;

        Quaternion targetCamPos1 = target.rotation;

        // Smoothly interpolate between the camera's current position and it's target position.
        transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);

        transform.LookAt(target);

        transform.rotation = Quaternion.Lerp (transform.rotation, targetCamPos1, smoothing * Time.deltaTime);


    }
}



