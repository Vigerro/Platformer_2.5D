using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatchProjectileCreator : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform[] Spawns;

    [ContextMenu("CreateProjectiles")]
    public void CreateProjectiles()
    {
        for (int i = 0; i < Spawns.Length; i++)
        {
            Instantiate(ProjectilePrefab, Spawns[i].position, Spawns[i].rotation);
        }
    }
}
