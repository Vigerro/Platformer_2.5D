using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public List<ActivateByDistance> ObjectsToActivate = new List<ActivateByDistance>();
    public Transform PlayerTransform;
    void Start()
    {
        PlayerTransform = FindObjectOfType<PlayerHp>().transform;
    }

    void Update()
    {
        foreach(ActivateByDistance obj in ObjectsToActivate)
        {
            obj.ChekDistance(PlayerTransform.position);

        }
    }

    public bool IsAllEnemiesDisabled()
    {

        foreach (var obj in ObjectsToActivate)
        {
            if (obj.isActiveAndEnabled)
            {
                return false;
            }
        }

        return true;
    }
      
    
}
