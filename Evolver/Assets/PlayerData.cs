using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    // # 스탯 변수들
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
    public bool Starve1;    public bool Starve2;    public bool Starve3;    public float tempDMG;   public int Starvation;
    // # 아이템 변수
    public int Bandage; public int Medikit; public int StaminaPotion;   public int MutantSample;    public int Food;    public int Water;

    // # 스킬 변수
    //public Skill_Manager[] scripts;
    [System.Serializable]
    public struct SkillContainer
    {
        public bool Selected_Once;
        public bool Selected_Twice;
        public bool Selected_Third;
    }
    public SkillContainer[] SC = new SkillContainer[100];
    //public Physical_Manager[] Physic_Scripts;
    [System.Serializable]
    public struct PhysicalSkillContainer
    {
        public bool Selected;
    }
    public PhysicalSkillContainer[] PC = new PhysicalSkillContainer[100];
    public PlayerData()
    {
        // default 생성자에서는 PlayerStat의 모든 능력치를 저장
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
        Starvation = Player_Stat.instance.Starvation;
        Starve1 = Player_Stat.instance.Starve1;
        Starve2 = Player_Stat.instance.Starve2;
        Starve3 = Player_Stat.instance.Starve3;
        tempDMG = Player_Stat.instance.tempDMG;
    }

    // # 여기서 얘한테 Skill_System_In_Map을 넘겨주어야 한다. 될까....?
    public PlayerData(GameObject SkillSystem, int i)
    {
        //scripts = SkillSystem.GetComponent<Skill_Manager>().scripts;
        foreach(Skill_Manager sm in SkillSystem.GetComponent<Skill_Manager>().scripts)
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

    public PlayerData(GameObject PhysicSkill)
    {
        int i = 0;
        //Physic_Scripts = PhysicSkill.GetComponent<Physical_Manager>().scripts;
        //PhysicalSkillContainer[] PC = new PhysicalSkillContainer[PhysicSkill.GetComponent<Physical_Manager>().scripts.Length];
        foreach(Physical_Manager pm in PhysicSkill.GetComponent<Physical_Manager>().scripts)
        {
            if (pm.Selected)
                PC[i].Selected = true;

            i++;
        }
    }

    public PlayerData(GameObject BackPack, bool checker)
    {
        MutantSample = BackPack.GetComponent<BackPack>().GetItemCount("MutantSample");
        Bandage = BackPack.GetComponent<BackPack>().GetItemCount("Bandage");
        Medikit = BackPack.GetComponent<BackPack>().GetItemCount("Medikit");
        StaminaPotion = BackPack.GetComponent<BackPack>().GetItemCount("StaminaPotion");
        Food = BackPack.GetComponent<BackPack>().GetItemCount("Food");
        Water = BackPack.GetComponent<BackPack>().GetItemCount("Water");
    }
}
