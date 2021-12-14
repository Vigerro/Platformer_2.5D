using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum RopeState
{
    Disabled,
    Active,
    Fly
}
public class RopeGun : MonoBehaviour
{
    [SerializeField] private Hook _hook;
    [SerializeField] private Transform _spawn;
    [SerializeField] private Transform _ropeStart;
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _ropeSpring = 100f;
    [SerializeField] private float _ropeDamper = 5f;

    [SerializeField] private RopeState _currentState = RopeState.Disabled;

    [SerializeField] private AudioSource _ropeSound;

    [SerializeField] private RopeRenderer _ropeRenderer;

    [SerializeField] private PlayerController _playerController;

    private float _length;

    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Shot();
        }
        if(_currentState == RopeState.Fly)
        {
            _ropeRenderer.Draw(_spawn.position, _hook.transform.position, _length);
            float distance = Vector3.Distance(_ropeStart.position, _hook.transform.position);
            if (distance > 20f)
            {
                _hook.gameObject.SetActive(false);
                _currentState = RopeState.Disabled;
                _ropeRenderer.Hide();
            }
        }
        if(_currentState == RopeState.Active)
        {
            _ropeRenderer.Draw(_spawn.position, _hook.transform.position, _length);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BreakSpring();
                _ropeRenderer.Hide();
                _currentState = RopeState.Disabled;
                if(_playerController.IsGrounded == false)
                {
                    _playerController.Jump();
                }
            }
        }
    }

    public void CreateSpring()
    {
        if (_springJoint == null)
        {
            _springJoint = gameObject.AddComponent<SpringJoint>();
        }
        _springJoint.connectedBody = _hook.Rigidbody;
        _springJoint.anchor = _ropeStart.localPosition;
        _springJoint.autoConfigureConnectedAnchor = false;
        _springJoint.connectedAnchor = Vector3.zero;
        _springJoint.spring = _ropeSpring;
        _springJoint.damper = _ropeDamper;
        _length = Vector3.Distance(_ropeStart.position, _hook.transform.position);
        _springJoint.maxDistance = _length - 0.5f;
        _currentState = RopeState.Active;
    }

    private void Shot()
    {
        _length = 1f;
        _ropeRenderer.Hide();
        _currentState = RopeState.Fly;
        BreakSpring();
        _hook.gameObject.SetActive(true);
        _hook.StopFix();
        _hook.transform.position = _spawn.position;
        _hook.Rigidbody.velocity = _spawn.forward * _speed;
        _ropeSound.Play();
    }

    private void BreakSpring()
    {
        if (_springJoint)
        {
            Destroy(_springJoint);
        }
        _hook.gameObject.SetActive(false);
    }
    
}
