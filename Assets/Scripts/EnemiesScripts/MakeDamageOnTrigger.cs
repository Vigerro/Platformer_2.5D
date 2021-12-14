using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    public int DamageValue = 1;

    private void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<PlayerHp>())
            {
                other.attachedRigidbody.GetComponent<PlayerHp>().TakeDamage(DamageValue);
            }
        }
    }
}
