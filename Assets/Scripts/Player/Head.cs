using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public Transform HeadPos;
    public Transform Aim;

    public float RotationAngle = 40f;
    public float RotationSpeed = 15f;

    void Update()
    {
        transform.position = HeadPos.position;
        if (Aim.position.x > transform.position.x)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, -RotationAngle, 0), Time.deltaTime * RotationSpeed);
        }
        else
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, RotationAngle, 0), Time.deltaTime * RotationSpeed);
        }
    }
}
