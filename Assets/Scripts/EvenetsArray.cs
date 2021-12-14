using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EvenetsArray : MonoBehaviour
{
    public UnityEvent[] Events;

    public void StartEvents(int eventIndex)
    {
        Events[eventIndex].Invoke();
    }
}
