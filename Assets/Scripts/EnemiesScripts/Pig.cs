using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public Transform RayStart;
 
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(RayStart.position, Vector3.down, out hit))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }
    }
}
