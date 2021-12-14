using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTargetEuler : MonoBehaviour
{
    [SerializeField] Vector3 _leftEuler;
    [SerializeField] Vector3 _rightEuler;
    Vector3 _targetEuler;

    [SerializeField] float _rotaitonSpeed;
  
    void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_targetEuler), Time.deltaTime * _rotaitonSpeed);
    }
    public void TurnLeft()
    {
        _targetEuler = _leftEuler;
    }
    
    public void TurnRight()
    {
        _targetEuler = _rightEuler;
    }
}
