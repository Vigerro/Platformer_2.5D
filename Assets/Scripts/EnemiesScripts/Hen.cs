using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    public float Speed;
    public float TimeToReachSpeed;
    private Transform _playerTransform;
    private Rigidbody _rigidbody;

    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerController>().transform;
        _rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized * Speed;
        Vector3 force = _rigidbody.mass * (toPlayer - _rigidbody.velocity) / TimeToReachSpeed;
        _rigidbody.AddForce(force);
    }
}
