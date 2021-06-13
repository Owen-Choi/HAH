using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class Player_Stat : MonoBehaviour
{
    public int Level = 1;               public bool isLevelUp;          public int Physical_Level = 1;  public bool isPhysical_LevelUp;
    public float health;                public float healthMax;         public float RadioActive;   public float DefaultHealthMax;  public float DefaultStaminaMax; public float thirsty;
    public float stamina;               public float armor;             public float Max_Stamina;   public float Stamina_recovery_speed = 5f;
    public float missPercent;           public float criticalPercent;   public float Decrease_Stamina_When_Bow_Charge = 5f;         //always check not only in script value, but also Insepctor value
    public float criticalDamage;        public float launchForce = 4f;  public float moveSpeed = 4f;  
    public static Player_Stat instance; public float speedForDash = 2f; public float SlowForCharge = 0.5f;  public bool AbsolCrit;  public bool Runner;
    public float damage;                public float Charge_Damage_Plus = 6f;   public bool is_Continued_Shot; public bool is_Continued_Shot2;  public bool is_Penetrate3;
    public float Burn_Percent;          public bool isPyro;             public int FireborneMax = 1;    public float Burning_DMG;
    public float Explode_Multiple_Damage;  public float ChargingSpeed;     public int dashCool;    public float DashTime; public float burningTime;
    public bool isNapalm2;
    public bool isLight;    public bool isSilver;   public bool isFire;
    public int Starvation;  public bool Starve1;    public bool Starve2;    public bool Starve3;   public float tempDMG;


    void Awake()
    {
        // # �ʱⰪ���� �����Ǿ�� �ϴ� ���� �߰��ϱ�
        instance = this;
        healthMax = 100f;
        RadioActive = 0f;
        DefaultHealthMax = 100f;
        DefaultStaminaMax = 100f;
        Max_Stamina = DefaultStaminaMax;
        is_Continued_Shot = false;
        is_Continued_Shot2 = false;
        ChargingSpeed = 1.2f;
        criticalDamage = 150f;
        criticalPercent = 10f;
        dashCool = 30;
        DashTime = 0.4f;
        Burning_DMG = 7f;
        burningTime = 5f;
        

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
        if (Max_Stamina >= DefaultStaminaMax)           //DefaultStaminaMax : ���׹̳��� ������ �ִ밪. �񸶸��� ���� �Ͻ��� �ִ뽺�׹̳��� �ƴ϶� ĳ������ ���� �ִ� ���׹̳��� ��Ÿ���� ���̴�.
            Max_Stamina = DefaultStaminaMax;
       if(stamina < 0)
        {
            stamina = 0;
        }

       if(health >= healthMax)
        {
            health = healthMax;
        }

        if (healthMax >= DefaultHealthMax)              //DefaultHealthMax : ü���� ������ �ִ밪. ���ɿ� ���� �Ͻ��� �ִ�ü���� �ƴ϶� ĳ������ ���� �ִ�ü���� ��Ÿ���� ���̴�.
            healthMax = DefaultHealthMax;

        healthMax = DefaultHealthMax - RadioActive;
        Max_Stamina = DefaultStaminaMax - thirsty;

        if (armor < 0) armor = 0;
        if (damage < 0) damage = 1;             //�ɷ�ġ���� ������ �ƴ� 0���� ����� �� �ڵ�. �ٸ� �ɷ�ġ�鵵 ���߿� �߰��ϵ��� ����.


        if(Starvation >= 30 && !Starve1)
        {
            Stamina_recovery_speed -= 0.5f;      
            Starve1 = true;
        }
        else if(Starve1 && Starvation < 30)
        {
            Starve1 = false;
            Stamina_recovery_speed += 0.5f;     //�г�Ƽ �ؼ�
        }


        if(Starvation >= 60 && !Starve2)
        {
            Stamina_recovery_speed -= 0.5f;
            moveSpeed -= 0.5f;
            Starve2 = true;
        }
        else if(Starve2 && (Starvation >= 30 && Starvation < 60))
        {
            Starve2 = false;
            Stamina_recovery_speed += 0.5f;
            moveSpeed += 0.5f;
        }

        if(Starvation >= 90 && !Starve3)
        {
            Stamina_recovery_speed -= 0.35f;
            moveSpeed -= 0.5f;
            tempDMG = damage * 0.5f;
            damage -= tempDMG;
            Starve3 = true;
        }
        else if(Starve3 && (Starvation >= 60 && Starvation < 90))
        {
            Stamina_recovery_speed += 0.35f;
            moveSpeed += 0.5f;
            damage += tempDMG;
            Starve3 = false;
        }

        

        
    }
}
