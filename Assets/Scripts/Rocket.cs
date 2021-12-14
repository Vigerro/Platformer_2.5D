using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject DieEffect;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _rotationSpeed = 3f;
    private Transform _playerTransform;
    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerHp>().transform;
    }

    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * _speed;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0); //выравнивает ракету по z
        if (_playerTransform)
        {
            Vector3 toPlayer = _playerTransform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
        }
        
    }

    public void OnDestroy()
    {
        Instantiate(DieEffect, transform.position, Quaternion.identity);
    }
}
