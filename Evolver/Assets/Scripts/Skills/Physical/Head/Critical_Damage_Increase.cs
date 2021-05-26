using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Critical_Damage_Increase : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 35;
        this.Sprite_Num = 38;
        this.Skill_Name = "Increase critical damage";
        this.Skill_Desc = "";
    }
    private void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.criticalDamage += 30f;
        }
    }
}
