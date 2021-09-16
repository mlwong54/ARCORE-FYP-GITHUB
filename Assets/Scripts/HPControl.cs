using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameSystem.Events;

public class HPControl : MonoBehaviour
{
    [SerializeField]
    private VoidEvent gameOverEvent;
    [SerializeField]
    private VoidEvent painSound;
    //[SerializeField]
    //private VoidEvent deathSound;
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private FloatValue playerHP;
    [SerializeField]
    private Gradient gradient;
    [SerializeField]
    private Image fill;
    private float addValue = 70;

    [SerializeField]
    private TimerScoreControl scoreControl;

    private void Start()
    {
        SetMaxHealth(playerHP.runtimeValue);
    }

    public void SetMaxHealth(float health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetNegativeHealth(float damage, float baseHealth)
    {
        healthBar.value = baseHealth - damage;

        fill.color = gradient.Evaluate(healthBar.normalizedValue);
    }

    public void SetPositiveHealth(float add, float baseHealth)
    {
        healthBar.value = baseHealth + add;
        if (healthBar.value >= 300)
        {
            healthBar.value = 300;
        }
        fill.color = gradient.Evaluate(healthBar.normalizedValue);
    }

    public void Damage(float damageValue)
    {
        playerHP.runtimeValue = playerHP.runtimeValue - damageValue;
        Debug.Log("received damage :" + damageValue);
        SetNegativeHealth(damageValue, playerHP.runtimeValue);
        painSound.Raise();
        if (playerHP.runtimeValue < 0)
        {
            Debug.Log("game over!");
            Destroy(gameObject, 0.2f);
            scoreControl.SaveScore();
            gameOverEvent.Raise();
            //deathSound.Raise();
        }
    }

    public void AddHealth()
    {
        if (playerHP.runtimeValue >= 300)
        {
            playerHP.runtimeValue = 300;
            Debug.Log("full health !");
        }
        else if (playerHP.runtimeValue < 300)
        {
            playerHP.runtimeValue = playerHP.runtimeValue + addValue;
            Debug.Log("received health :" + addValue);
            SetPositiveHealth(addValue, playerHP.runtimeValue);
        }
    }
}
