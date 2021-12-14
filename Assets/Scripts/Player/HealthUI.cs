using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public GameObject HealthIconPrefab;

    private List<GameObject> HealthIcons = new List<GameObject>();

    public void Setup(int MaxHealth)
    {
        for(int i = 0; i < MaxHealth; i++)
        {
            GameObject newIcon = Instantiate(HealthIconPrefab, transform);
            HealthIcons.Add(newIcon);
        }
    }
    
    public void DisplayHealth(int CurrentHP)
    {
        for (int i = 0; i < HealthIcons.Count; i++)
        {
            if(i < CurrentHP)
            {
                HealthIcons[i].SetActive(true);
            }
            else
            {
                HealthIcons[i].SetActive(false);
            }    
        }
    }
}
