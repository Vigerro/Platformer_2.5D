using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float FollowSpeed;

    public Transform Target;
   
    void Update()
    {
        if(Target)
        {
            transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * FollowSpeed);   
        }
       
    }
}
