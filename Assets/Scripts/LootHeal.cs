using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
    public int HealtValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody)
        {
            if(other.attachedRigidbody.GetComponent<PlayerHp>())
            {
                other.attachedRigidbody.GetComponent<PlayerHp>().AddHealth(HealtValue);
                OnPickedUp();
            }    
        }
    }

    void OnPickedUp()
    {
        Destroy(gameObject);
    }
}
