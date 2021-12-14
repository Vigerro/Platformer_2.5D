using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject WinScreen;
    public Menu Menu;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<PlayerHp>())
            {
                Win();
            }
        }

    }

    void Win()
    {
        WinScreen.SetActive(true);
        Cursor.visible = true;
        Menu.DisablePlayerComponents();
        Time.timeScale = 0f;
        
    }
}
  
