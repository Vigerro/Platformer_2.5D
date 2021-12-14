using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    [SerializeField] private float _turnSpeed = 5f;
    [SerializeField] private Vector3 _leftEuler;
    [SerializeField] private Vector3 _rightEuler;

    private Transform _playerTransform;
    private Vector3 _targetEuler;
    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerHp>().transform;    
    }

    void Update()
    {
        if(_playerTransform)
        {
            if (transform.position.x < _playerTransform.position.x)
            {
                _targetEuler = _rightEuler;
            }
            else
            {
                _targetEuler = _leftEuler;
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * _turnSpeed);
        }
        
    }
}
