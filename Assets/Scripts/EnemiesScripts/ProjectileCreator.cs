using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCreator : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform Spawn;
   
    public void CreateProjectile()
    {
        Instantiate(ProjectilePrefab, Spawn.position, Spawn.rotation);
    }
}
