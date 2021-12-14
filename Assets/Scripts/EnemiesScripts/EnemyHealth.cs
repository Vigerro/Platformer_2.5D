using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public float Health = 3;
    public GameObject HitSound;
    public UnityEvent EventOnTakeDamage;
    public UnityEvent EventOnDie;

    public void TakeDamage(int DamageValue)
    {
        EventOnTakeDamage?.Invoke();
        Instantiate(HitSound);
        Health -= DamageValue;
        if (Health <= 0)
        {
            Die();
        }
       
    }


    void Die()
    {
        EventOnDie?.Invoke();
        Destroy(gameObject);
    }
}
