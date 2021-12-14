using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHp : MonoBehaviour
{
    public int Health = 5;
    public int MaxHealth = 8;

    public float InvulnerableTime = 1;

  
    public AudioSource AddHealthSound;

    public HealthUI HealthUI;

    public GameObject LoseScreen;

    public Menu Menu;

    public UnityEvent EventOnTakeDamage;

   

    private bool _invulnerable = false;
    void Start()
    {
        HealthUI.Setup(MaxHealth);
        HealthUI.DisplayHealth(Health);
    }
 
    public void TakeDamage(int DamageValue)
    {
        if (_invulnerable == false)
        {
            Health -= DamageValue;
            _invulnerable = true;
            Invoke("StopInvulnerable", InvulnerableTime);
            HealthUI.DisplayHealth(Health);
            EventOnTakeDamage.Invoke();
            if (Health <= 0)
            {
                Health = 0;
                Lose();
            }
        }
        
    }
    public void AddHealth(int HealtValue)
    {
        Health += HealtValue;
        if(Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        AddHealthSound.Play();
        HealthUI.DisplayHealth(Health);
    }
    void StopInvulnerable()
    {
        _invulnerable = false;
    }
    
    void Lose()
    {
        gameObject.SetActive(false);
        Cursor.visible = true;
        LoseScreen.SetActive(true);
        Menu.DisablePlayerComponents();
        Time.timeScale = 0f;
    }
}
