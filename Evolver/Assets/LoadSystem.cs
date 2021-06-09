using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LoadSystem
{
    public static void LoadStat()
    {
        PlayerData StatData = SaveSystem.LoadStat();
        StatData.Level = Player_Stat.instance.Level;
        StatData.Physical_Level = Player_Stat.instance.Physical_Level;
        StatData.health = Player_Stat.instance.health;
        StatData.healthMax = Player_Stat.instance.healthMax;
        StatData.RadioActive = Player_Stat.instance.RadioActive;
        StatData.DefaultHealthMax = Player_Stat.instance.DefaultHealthMax;
        StatData.DefaultStaminaMax = Player_Stat.instance.DefaultStaminaMax;
        StatData.thirsty = Player_Stat.instance.thirsty;
        StatData.stamina = Player_Stat.instance.stamina;
        StatData.armor = Player_Stat.instance.armor;
        StatData.Max_Stamina = Player_Stat.instance.Max_Stamina;
        StatData.Stamina_recovery_speed = Player_Stat.instance.Stamina_recovery_speed;
        StatData.missPercent = Player_Stat.instance.missPercent;
        StatData.criticalPercent = Player_Stat.instance.criticalPercent;
        StatData.Decrease_Stamina_When_Bow_Charge = Player_Stat.instance.Decrease_Stamina_When_Bow_Charge;
        StatData.criticalDamage = Player_Stat.instance.criticalDamage;
        StatData.launchForce = Player_Stat.instance.launchForce;
        StatData.moveSpeed = Player_Stat.instance.moveSpeed;
        StatData.speedForDash = Player_Stat.instance.speedForDash;
        StatData.SlowForCharge = Player_Stat.instance.SlowForCharge;
        StatData.Runner = Player_Stat.instance.Runner;
        StatData.damage = Player_Stat.instance.damage;
        StatData.Charge_Damage_Plus = Player_Stat.instance.Charge_Damage_Plus;
        StatData.is_Continued_Shot = Player_Stat.instance.is_Continued_Shot;
        StatData.is_Continued_Shot2 = Player_Stat.instance.is_Continued_Shot2;
        StatData.is_Penetrate3 = Player_Stat.instance.is_Penetrate3;
        StatData.Burn_Percent = Player_Stat.instance.Burn_Percent;
        StatData.isPyro = Player_Stat.instance.isPyro;
        StatData.FireborneMax = Player_Stat.instance.FireborneMax;
        StatData.Burning_DMG = Player_Stat.instance.Burning_DMG;
        StatData.Explode_Multiple_Damage = Player_Stat.instance.Explode_Multiple_Damage;
        StatData.ChargingSpeed = Player_Stat.instance.ChargingSpeed;
        StatData.dashCool = Player_Stat.instance.dashCool;
        StatData.DashTime = Player_Stat.instance.DashTime;
        StatData.burningTime = Player_Stat.instance.burningTime;
        StatData.isNapalm2 = Player_Stat.instance.isNapalm2;
        StatData.isLight = Player_Stat.instance.isLight;
        StatData.isSilver = Player_Stat.instance.isSilver;
        StatData.isFire = Player_Stat.instance.isFire;
    }

    public static void LoadSkill()
    {
        GameObject SkillSystemCache;
        SkillSystemCache = GameObject.Find("Skill_System_In_Map");
        Skill_Manager[] scripts = SkillSystemCache.GetComponent<Skill_Manager>().scripts;
        PlayerData SkillData = SaveSystem.LoadSkill();
        int i = 0;

        foreach(Skill_Manager sm in scripts)
        {
            if (SkillData.SC[i].Selected_Once)
                sm.Selected_First = true;
            if (SkillData.SC[i].Selected_Twice)
                sm.Selected_Second = true;
            if (SkillData.SC[i].Selected_Third)
                sm.Selected_Last = true;
            i++;
        }
    }

    public static void LoadPhysicalSkill()
    {
        GameObject Physic_System_Cache;
        Physic_System_Cache = GameObject.Find("Physic_System");
        Physical_Manager[] scripts = Physic_System_Cache.GetComponent<Physical_Manager>().scripts;
        PlayerData PhysicData = SaveSystem.LoadPhysicalSkill();
        int i = 0;

        foreach(Physical_Manager pm in scripts)
        {
            if (PhysicData.PC[i].Selected)
                pm.Selected = true;
            i++;
        }
    }
}
