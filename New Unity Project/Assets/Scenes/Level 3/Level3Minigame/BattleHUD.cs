using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text levelText;

    public Slider healthSlider;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.name;
        levelText.text = "Level " + unit.level;
        healthSlider.maxValue = unit.maxHealth;
        healthSlider.value = unit.currentHealth;
    }

    public void setHealth(int health)
    {
        healthSlider.value = health;
    }
}
