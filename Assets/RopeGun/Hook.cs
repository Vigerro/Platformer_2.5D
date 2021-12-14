using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public Rigidbody Rigidbody;

    [SerializeField] private RopeGun _ropeGun;
    [SerializeField] private Collider _playerCollider;
    [SerializeField] private Collider _collider;

    [SerializeField] private AudioSource _hookSound;

    private FixedJoint _fixedJoint;

    private void Start()
    {
        Physics.IgnoreCollision(_playerCollider, _collider);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(_fixedJoint == null)
        {
            _fixedJoint = gameObject.AddComponent<FixedJoint>();
            _hookSound.Play();
            if (collision.rigidbody)
            {
                _fixedJoint.connectedBody = collision.rigidbody;
                _ropeGun.CreateSpring();
            }
        }
        
    }

    public void StopFix()
    {
        if(_fixedJoint)
        {
            Destroy(_fixedJoint);
        }
    }
}
