using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpGunIcon : MonoBehaviour
{
    [SerializeField] private Image _foreground;
    [SerializeField] private Image _background;
    [SerializeField] private Image _outline;
    [SerializeField] private Text _cooldownText;

    public void StartCharge()
    {
        _background.color = new Color(1f, 1f, 1f, 0.2f);
        _foreground.enabled = true;
        _cooldownText.enabled = true;
        _outline.enabled = false;
    }

    public void StopCharge()
    {
        _background.color = new Color(1f, 1f, 1f, 1f);
        _foreground.enabled = false;
        _cooldownText.enabled = false;
        _outline.enabled = true;
    }

    public void SetChargeValue(float currentCharge, float maxCharge)
    {
        _foreground.fillAmount = currentCharge / maxCharge;
        _cooldownText.text = (Mathf.Ceil(maxCharge - currentCharge)).ToString();
    }
}
