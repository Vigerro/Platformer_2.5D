using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Automat : Gun
{
    [Header("Automat")]
    public int NumberOfBullets;
    public PlayerArmory PlayerArmory;
    public Text BulletsText;

    public override void Shot()
    {
        base.Shot();
        NumberOfBullets--;
        UpdateText();
        if (NumberOfBullets <= 0)
        {
            PlayerArmory.TakeGunByIndex(0);
        }
    }
    public override void Activate()
    {
        base.Activate();
        BulletsText.enabled = true;
        UpdateText();
    }
    public override void Deactivate()
    {
        base.Deactivate();
        BulletsText.enabled = false;

    }
    public override void AddBullets(int BulletsCount)
    {
        NumberOfBullets += BulletsCount;
        PlayerArmory.TakeGunByIndex(1);
        UpdateText();
    }
    private void UpdateText()
    {
        BulletsText.text = "Пули: " + NumberOfBullets.ToString();
    }
}
