using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LoadSystem
{
    public static void LoadStat()
    {
        PlayerData StatData = SaveSystem.LoadStat();
        Player_Stat.instance.Level = StatData.Level;
        Player_Stat.instance.Physical_Level = StatData.Physical_Level;
        Player_Stat.instance.health = StatData.health;
        Player_Stat.instance.healthMax = StatData.healthMax;
        Player_Stat.instance.RadioActive = StatData.RadioActive;
        Player_Stat.instance.DefaultHealthMax = StatData.DefaultHealthMax;
        Player_Stat.instance.DefaultStaminaMax = StatData.DefaultStaminaMax;
        Player_Stat.instance.thirsty = StatData.thirsty;
        Player_Stat.instance.stamina = StatData.stamina;
        Player_Stat.instance.armor = StatData.armor;
        Player_Stat.instance.Max_Stamina = StatData.Max_Stamina;
        Player_Stat.instance.Stamina_recovery_speed = StatData.Stamina_recovery_speed;
        Player_Stat.instance.missPercent = StatData.missPercent;
        Player_Stat.instance.criticalPercent = StatData.criticalPercent;
        Player_Stat.instance.Decrease_Stamina_When_Bow_Charge = StatData.Decrease_Stamina_When_Bow_Charge;
        Player_Stat.instance.criticalDamage = StatData.criticalDamage;
        Player_Stat.instance.launchForce = StatData.launchForce;
        Player_Stat.instance.moveSpeed = StatData.moveSpeed;
        Player_Stat.instance.speedForDash = StatData.speedForDash;
        Player_Stat.instance.SlowForCharge = StatData.SlowForCharge;
        Player_Stat.instance.Runner = StatData.Runner;
        Player_Stat.instance.damage = StatData.damage;
        Player_Stat.instance.Charge_Damage_Plus = StatData.Charge_Damage_Plus;
        Player_Stat.instance.is_Continued_Shot = StatData.is_Continued_Shot;
        Player_Stat.instance.is_Continued_Shot2 = StatData.is_Continued_Shot2;
        Player_Stat.instance.is_Penetrate3 = StatData.is_Penetrate3;
        Player_Stat.instance.Burn_Percent = StatData.Burn_Percent;
        Player_Stat.instance.isPyro = StatData.isPyro;
        Player_Stat.instance.FireborneMax = StatData.FireborneMax;
        Player_Stat.instance.Burning_DMG = StatData.Burning_DMG;
        Player_Stat.instance.Explode_Multiple_Damage = StatData.Explode_Multiple_Damage;
        Player_Stat.instance.ChargingSpeed = StatData.ChargingSpeed;
        Player_Stat.instance.dashCool = StatData.dashCool;
        Player_Stat.instance.DashTime = StatData.DashTime;
        Player_Stat.instance.burningTime = StatData.burningTime;
        Player_Stat.instance.isNapalm2 = StatData.isNapalm2;
        Player_Stat.instance.isLight = StatData.isLight;
        Player_Stat.instance.isSilver = StatData.isSilver;
        Player_Stat.instance.isFire = StatData.isFire;
    }

    public static void LoadSkill()
    {
        GameObject SkillSystemCache;
        SkillSystemCache = GameObject.Find("Skill_System_In_Map");
        Skill_Manager[] scripts = SkillSystemCache.GetComponent<Skill_Manager>().scripts;
        scripts = SkillSystemCache.GetComponents<Skill_Manager>();
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
        scripts = Physic_System_Cache.GetComponents<Physical_Manager>();
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
