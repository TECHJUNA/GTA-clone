using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthcontroler : MonoBehaviour
{
    public float totalHealth = 100f;
    public float PlayerHealth;
    public Slider PlayerHealthSlider;
    public bool IstakingDamage = false;
    public bool IstakingHealing = false;
    public float HealingTime = 5f;
    public  float RemaningHealingTime;

    void Start()
    {
        PlayerHealth = totalHealth;
        RemaningHealingTime = HealingTime;
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.L)) 
        {
            DamagePlayer(25F);
        }
        if (IstakingDamage)
        {
            TakingDamage();
        }
        if(IstakingHealing)
        {
            StartHealing();
        }
        
    }
    public void DamagePlayer(float damage)
    {
        if (PlayerHealth <= 0)
        {
            PlayerHealth = 0;
        }
        else if(PlayerHealth > 100)
        {
            PlayerHealth = 100;
        }
        else
        {
            PlayerHealth = PlayerHealth - damage;
            RemaningHealingTime = HealingTime;
            IstakingDamage = true;
            IstakingHealing = false;  
        }
        PlayerHealthSlider.value = PlayerHealth;
    }

    public void TakingDamage()
    {
         RemaningHealingTime = RemaningHealingTime-Time.deltaTime;

        if (RemaningHealingTime <= 0)
        {
            IstakingDamage = false;
            IstakingHealing = true;
        }
    }

    public void StartHealing()
    {
        PlayerHealth = PlayerHealth + Time.deltaTime * 2;
        PlayerHealthSlider.value = PlayerHealth;
        if(PlayerHealth > 100f)
        {
            PlayerHealth = 100;
            IstakingHealing= false;
        }
    }
}
