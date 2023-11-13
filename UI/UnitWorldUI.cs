using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitWorldUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HealthPointText;
    [SerializeField] private Unit unit;
    [SerializeField] private Image healthBarImage;
    [SerializeField] private HealthSystem healthSystem;

    private void Start()
    {
        healthSystem.OnDamaged += HealthSystem_OnDamaged;
        UpdateHealthBar();
        UpdateHealthPointText();
    }

    private void UpdateHealthPointText()
    {
        HealthPointText.text = healthSystem.getHealth().ToString();
    }
    private void UpdateHealthBar()
    {
        healthBarImage.fillAmount = healthSystem.GetHealthNormalized();
    }
    
    private void HealthSystem_OnDamaged(object sender, EventArgs e)
    {
        UpdateHealthPointText();
        UpdateHealthBar();
    }
}
