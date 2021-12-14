using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MenuButton;
    public GameObject MenuWindow;

    public MonoBehaviour[] ComponentsToDisable;
    
    private bool _isOpen;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(_isOpen)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
    }
    public void OpenMenu()
    {
        Cursor.visible = true;
        MenuButton.SetActive(false);
        MenuWindow.SetActive(true);
        _isOpen = true;
        DisablePlayerComponents();
        Time.timeScale = 0f;
    }
    public void CloseMenu()
    {
        Cursor.visible = false;
        MenuButton.SetActive(true);
        MenuWindow.SetActive(false);
        _isOpen = false;
        EnablePlayerComponents();
        Time.timeScale = 1f;
    }

    public void DisablePlayerComponents()
    {
        foreach (var component in ComponentsToDisable)
        {
            component.enabled = false;
        }
    }

    public void EnablePlayerComponents()
    {
        foreach (var component in ComponentsToDisable)
        {
            component.enabled = true;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
