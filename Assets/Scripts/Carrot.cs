using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float Speed;
    public float LifeTime = 9f;
    
    void Start()
    {
        transform.rotation = Quaternion.identity;
        Transform playerTransform = FindObjectOfType<PlayerController>().transform;
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
        Rigidbody.velocity = toPlayer * Speed;
        Destroy(gameObject, LifeTime);
    }

    
}
