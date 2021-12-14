using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDoor : MonoBehaviour
{
    public GameObject OpenSound;
    public Transform PlayerTransform;
    public Animator DoorAnimator;
    public Activator Enemies;

    [SerializeField] private float _distanceToOpen = 10f;

    private bool _isClosed = true;
    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, PlayerTransform.position);

        if (distanceToPlayer < _distanceToOpen && _isClosed)
        {
            if (Enemies.IsAllEnemiesDisabled())
            {
                OpenDoor();
            }
            
        }
    }

   
    [ContextMenu("OpenDoor")]
    public void OpenDoor()
    {
        DoorAnimator.SetTrigger("Open");
        OpenSound.SetActive(true);
        _isClosed = false;
    }
}
