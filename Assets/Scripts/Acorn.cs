using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    [SerializeField] private Vector3 Velocity;
    [SerializeField] private float _maxAngleSpeed;

    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Velocity, ForceMode.VelocityChange);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(
            Random.Range(-_maxAngleSpeed, _maxAngleSpeed), 
            Random.Range(-_maxAngleSpeed, _maxAngleSpeed), 
            Random.Range(-_maxAngleSpeed, _maxAngleSpeed)
            );
    }
}
