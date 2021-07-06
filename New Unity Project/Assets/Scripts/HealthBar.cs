using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthbar;

    public Gradient gradient;

    public Image fill;
    
    public void SetHealth(int health)
    {
        healthbar.value = health;
        fill.color = gradient.Evaluate(healthbar.normalizedValue);
    }

    public void SetMaxHealth(int health)
    {
        healthbar.maxValue = health;
        healthbar.value = health;
        fill.color = gradient.Evaluate(1.0f);
    }
}
