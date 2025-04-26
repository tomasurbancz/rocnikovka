using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar 
{
    public Slider Slider;
    public TMP_Text HealthText;
    public int HP;
    public int MaxHP;

    public HealthBar(Slider slider, TMP_Text healthText, int hp, int maxHP)
    {
        Slider = slider;
        HealthText = healthText;
        HP = hp;
        MaxHP = maxHP;
    }

    public void UpdateHP(int hp)
    {
        HP -= hp;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        Slider.value = ((float) HP / MaxHP);
        HealthText.text = Mathf.Max(0, HP) + "/" + MaxHP;
    }
}
