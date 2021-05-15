using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stat : MonoBehaviour
{
    public int Level = 1;               public bool isLevelUp;          public int Physical_Level = 1;  public bool isPhysical_LevelUp;
    public float health;                public float healthMax;         public float RadioActive;   public float DefaultHealthMax;  public float DefaultStaminaMax;
    public float stamina;               public float armor;             public float Max_Stamina;   public float Stamina_recovery_speed = 5f;
    public float missPercent;           public float criticalPercent;   public float Decrease_Stamina_When_Bow_Charge = 5f;         //always check not only in script value, but also Insepctor value
    public float criticalDamage;        public float launchForce = 4f;  public float moveSpeed = 4f;  
    public static Player_Stat instance; public float speedForDash = 2f; public float SlowForCharge = 0.5f;  public bool AbsolCrit;
    public float damage;                public float Charge_Damage_Plus = 6f;   public bool is_Continued_Shot; public bool is_Continued_Shot2;  public bool is_Penetrate3;
    public float Burn_Percent;          public bool isPyro;             public int FireborneMax = 1;    public float Burning_DMG;
    public float Explode_Multiple_Damage;   public bool isShelter;      public float ChargingSpeed;

    void Awake()
    {
        instance = this;
        healthMax = 100f;
        RadioActive = 0f;
        DefaultHealthMax = 100f;
        DefaultStaminaMax = 100f;
        Max_Stamina = DefaultStaminaMax;
        isShelter = true;
        is_Continued_Shot = false;
        is_Continued_Shot2 = false;
        ChargingSpeed = 1.2f;
        criticalDamage = 150f;
        criticalPercent = 10f;
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
        if (Max_Stamina >= DefaultStaminaMax)           //DefaultStaminaMax : 스테미나의 절대적 최대값. 목마름에 의한 일시적 최대스테미나가 아니라 캐릭터의 원래 최대 스테미나를 나타내는 값이다.
            Max_Stamina = DefaultStaminaMax;
       if(stamina < 0)
        {
            stamina = 0;
        }

       if(health >= healthMax)
        {
            health = healthMax;
        }

        if (healthMax >= DefaultHealthMax)              //DefaultHealthMax : 체력의 절대적 최대값. 방사능에 의한 일시적 최대체력이 아니라 캐릭터의 원래 최대체력을 나타내는 값이다.
            healthMax = DefaultHealthMax;

    }
}
