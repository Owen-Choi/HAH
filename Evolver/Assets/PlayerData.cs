using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    // # ���� ������
    public int Level; public int Physical_Level;
    public float health; public float healthMax; public float RadioActive; public float DefaultHealthMax; public float DefaultStaminaMax; public float thirsty;
    public float stamina; public float armor; public float Max_Stamina; public float Stamina_recovery_speed;
    public float missPercent; public float criticalPercent; public float Decrease_Stamina_When_Bow_Charge;
    public float criticalDamage; public float launchForce; public float moveSpeed;
    public float speedForDash; public float SlowForCharge; public bool Runner;
    public float damage; public float Charge_Damage_Plus; public bool is_Continued_Shot; public bool is_Continued_Shot2; public bool is_Penetrate3;
    public float Burn_Percent; public bool isPyro; public int FireborneMax; public float Burning_DMG;
    public float Explode_Multiple_Damage; public float ChargingSpeed; public int dashCool; public float DashTime; public float burningTime;
    public bool isNapalm2;
    public bool isLight; public bool isSilver; public bool isFire;

    // # ��ų ����
    public Skill_Manager[] scripts;
    public struct SkillContainer
    {
        public bool Selected_Once;
        public bool Selected_Twice;
        public bool Selected_Third;
    }

    public PlayerData()
    {
        // default �����ڿ����� PlayerStat�� ��� �ɷ�ġ�� ����
        Level = Player_Stat.instance.Level;
        Physical_Level = Player_Stat.instance.Physical_Level;
        health = Player_Stat.instance.health;
        healthMax = Player_Stat.instance.healthMax;
        RadioActive = Player_Stat.instance.RadioActive;
        DefaultHealthMax = Player_Stat.instance.DefaultHealthMax;
        DefaultStaminaMax = Player_Stat.instance.DefaultStaminaMax;
        thirsty = Player_Stat.instance.thirsty;
        stamina = Player_Stat.instance.stamina;
        armor = Player_Stat.instance.armor;
        Max_Stamina = Player_Stat.instance.Max_Stamina;
        Stamina_recovery_speed = Player_Stat.instance.Stamina_recovery_speed;
        missPercent = Player_Stat.instance.missPercent;
        criticalPercent = Player_Stat.instance.criticalPercent;
        Decrease_Stamina_When_Bow_Charge = Player_Stat.instance.Decrease_Stamina_When_Bow_Charge;
        criticalDamage = Player_Stat.instance.criticalDamage;
        launchForce = Player_Stat.instance.launchForce;
        moveSpeed = Player_Stat.instance.moveSpeed;
        speedForDash = Player_Stat.instance.speedForDash;
        SlowForCharge = Player_Stat.instance.SlowForCharge;
        Runner = Player_Stat.instance.Runner;
        damage = Player_Stat.instance.damage;
        Charge_Damage_Plus = Player_Stat.instance.Charge_Damage_Plus;
        is_Continued_Shot = Player_Stat.instance.is_Continued_Shot;
        is_Continued_Shot2 = Player_Stat.instance.is_Continued_Shot2;
        is_Penetrate3 = Player_Stat.instance.is_Penetrate3;
        Explode_Multiple_Damage = Player_Stat.instance.Explode_Multiple_Damage;
        ChargingSpeed = Player_Stat.instance.ChargingSpeed;
        dashCool = Player_Stat.instance.dashCool;
        DashTime = Player_Stat.instance.DashTime;
        burningTime = Player_Stat.instance.burningTime;
        isNapalm2 = Player_Stat.instance.isNapalm2;
        isLight = Player_Stat.instance.isLight;
        isSilver = Player_Stat.instance.isSilver;
        isFire = Player_Stat.instance.isFire;
    }

    // # ���⼭ ������ Skill_System_In_Map�� �Ѱ��־�� �Ѵ�. �ɱ�....?
    public PlayerData(GameObject SkillSystem)
    {
        int i = 0;
        scripts = SkillSystem.GetComponent<Skill_Manager>().scripts;
        SkillContainer[] SC = new SkillContainer[scripts.Length];
        foreach(Skill_Manager sm in scripts)
        {
            if (sm.Selected_First)
                SC[i].Selected_Once = true;
            if (sm.Selected_Second)
                SC[i].Selected_Twice = true;
            if (sm.Selected_Last)
                SC[i].Selected_Third = true;

            i++;
        }
    }

    public PlayerData(Physical_Manager PhysicSkill)
    {

    }
}
