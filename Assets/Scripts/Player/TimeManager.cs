using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _timeScale = 1f;

    private float _startFixedDeltaTime;
    private bool _isTimeStoped;

    private void Start()
    {
        _startFixedDeltaTime = Time.fixedDeltaTime;
    }
    private void Update()
    {
        _timeScale = 1f;
        if (Input.GetMouseButton(1))
        {
            _timeScale = 0.35f;
        }

        Time.timeScale = _timeScale;
        
           
        Time.fixedDeltaTime = _startFixedDeltaTime * Time.timeScale;
    }

    private void OnDestroy()
    {
        Time.fixedDeltaTime = _startFixedDeltaTime;
    }

}
