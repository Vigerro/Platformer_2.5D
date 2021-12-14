using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject EffectPrefab;

    public bool IsActive;
    void Start()
    {
        IsActive = true;
        Invoke(nameof(Die), 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(EffectPrefab, transform.position, Quaternion.identity);
        Die();   
    }

    public void Die()
    {
        IsActive = false;
        Destroy(gameObject);
    }
}
