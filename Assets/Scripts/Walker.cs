using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Directon
{
    Left,
    Right
}
public class Walker : MonoBehaviour
{
    [SerializeField] private Transform _leftTarget;
    [SerializeField] private Transform _rightTarget;

    [SerializeField] private float _stopTime;
    [SerializeField] private float _speed;

    [SerializeField] Directon CurrentDirection;

    public UnityEvent EventOnLeftTarget;
    public UnityEvent EventOnRightTarget;

    private bool _canWalk = true;
    void Start()
    {
        _leftTarget.parent = null;
        _rightTarget.parent = null;
    }

  
    void Update()
    {
        if(_canWalk == false)
        {
            return;
        }

        if(CurrentDirection == Directon.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * _speed, 0, 0);
            if(transform.position.x < _leftTarget.position.x)
            {
                CurrentDirection = Directon.Right;
                _canWalk = false;
                Invoke(nameof(StartWalking), _stopTime);
                EventOnLeftTarget.Invoke();
            }
        }else
        {
            transform.position += new Vector3(Time.deltaTime * _speed, 0, 0);
            if (transform.position.x > _rightTarget.position.x)
            {
                CurrentDirection = Directon.Left;
                _canWalk = false;
                Invoke(nameof(StartWalking), _stopTime);
                EventOnRightTarget.Invoke();
            }
        }
        
    }

    void StartWalking()
    {
        _canWalk = true;
    }
}
