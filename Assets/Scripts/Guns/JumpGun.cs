using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
    [SerializeField] private Transform _spawn;
    [SerializeField] private Rigidbody _playerRb;
    [SerializeField] private Gun Pistol;
    [SerializeField] private JumpGunIcon ChargeIcon;

    [SerializeField] private float _force; 
    [SerializeField] private float _maxCharge = 3f;

    private float _currentCharge = 0f;
    private bool _isCharged = true;

    private void Update()
    {
        if (_isCharged) {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _playerRb.AddForce(-(_spawn.forward) * _force, ForceMode.VelocityChange);
                Pistol.Shot();
                _isCharged = false;
                _currentCharge = 0;
                ChargeIcon.StartCharge();
            }
        }
        else
        {
            _currentCharge += Time.unscaledDeltaTime;
            ChargeIcon.SetChargeValue(_currentCharge, _maxCharge);
            if (_currentCharge >= _maxCharge)
            {
                _isCharged = true;
                ChargeIcon.StopCharge();
            }
         
        }

    }
}
