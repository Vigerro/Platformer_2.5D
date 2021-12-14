using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public bool DieOnAnyCollision;
    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody)
        {
            Bullet bullet = other.attachedRigidbody.GetComponent<Bullet>();
            if (bullet)
            {

                if (bullet.IsActive)
                {
                    EnemyHealth.TakeDamage(1);
                    bullet.Die();
                }


            }
        }
        if (DieOnAnyCollision)
        {
            if (other.isTrigger == false)
             EnemyHealth.TakeDamage(10000);
        }
    }
}
