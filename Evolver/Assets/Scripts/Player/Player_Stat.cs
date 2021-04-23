using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stat : MonoBehaviour
{
    public float health;                public float healthMax;         public float RadioActive;   public float DefaultHealthMax;  public float DefaultStaminaMax;
    public float stamina;               public float armor;             public float Max_Stamina;   float Stamina_recovery_speed = 5f;
    public float missPercent;           public float criticalPercent;   public float Decrease_Stamina_When_Bow_Charge = 5f;         //always check not only in script value, but also Insepctor value
    public float criticalDamage;        public float launchForce = 4f;  public float moveSpeed = 4f;  
    public static Player_Stat instance; public float speedForDash = 2f; public float SlowForCharge = 0.5f;  public bool AbsolCrit;
    public float damage;                public float Charge_Damage_Plus = 6f;   public bool is_Continued_Shot; public bool is_Continued_Shot2;  public bool is_Penetrate3;
    public float Burn_Percent;          public bool isPyro;             public int FireborneMax = 1;    public float Burning_DMG;
    public float Explode_Multiple_Damage;

    void Awake()
    {
        instance = this;
        healthMax = 100f;
        RadioActive = 0f;
        DefaultHealthMax = 100f;
        DefaultStaminaMax = 100f;
        Max_Stamina = DefaultStaminaMax;
    }

    public void Update()
    {

       if(stamina < Max_Stamina)
        {
            stamina += Time.deltaTime * Stamina_recovery_speed; 
        }
       if(stamina > Max_Stamina)
        {
            stamina = Max_Stamina;
        }
        if (Max_Stamina >= DefaultStaminaMax)
            Max_Stamina = DefaultStaminaMax;
       if(stamina < 0)
        {
            stamina = 0;
        }

       if(health >= healthMax)
        {
            health = healthMax;
        }

        if (healthMax >= DefaultHealthMax)
            healthMax = DefaultHealthMax;
    }
}
