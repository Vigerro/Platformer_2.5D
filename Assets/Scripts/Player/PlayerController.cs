using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;
    public float Friction;
    public float SpeedMultiplyer;
    public float MaxSpeed;

    public bool IsGrounded = false;

    public Transform ColliderTransform;

    [SerializeField] private float _spin = 10f;

    private Rigidbody _playerRb;
    private int _jumpFrameCounter = 3;
    void Start()
    {
        Cursor.visible = false;
        _playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || !IsGrounded)
        {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 15f);
        }
        else
        {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 20f);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(IsGrounded)
            {
                Jump();
            }
        }
    }
    void FixedUpdate()
    {
        SpeedMultiplyer = 1;
        if (!IsGrounded)
            SpeedMultiplyer = 0.2f;

        if (IsGrounded)
        {
            _playerRb.AddForce(-_playerRb.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15f);
        }
           

        if (Input.GetAxis("Horizontal") > 0 && _playerRb.velocity.x > MaxSpeed && !IsGrounded)
            SpeedMultiplyer = 0;

        if (Input.GetAxis("Horizontal") < 0 && _playerRb.velocity.x < -MaxSpeed && !IsGrounded)
            SpeedMultiplyer = 0;

        _playerRb.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * SpeedMultiplyer, 0, 0, ForceMode.VelocityChange);

        _jumpFrameCounter += 1;
        if(_jumpFrameCounter == 2)
        {
            if(Random.Range(0, 4) == 0)
            {
                _playerRb.freezeRotation = false;
                _playerRb.AddRelativeTorque(0f, 0f, _spin, ForceMode.VelocityChange);
            }     
        }
    }

    public void Jump()
    {
        _playerRb.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
        _jumpFrameCounter = 0;
    }
    private void OnCollisionStay(Collision collision)
    {
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);
        if (angle < 45)
        {
            IsGrounded = true;
            _playerRb.freezeRotation = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        IsGrounded = false;
    }
}
