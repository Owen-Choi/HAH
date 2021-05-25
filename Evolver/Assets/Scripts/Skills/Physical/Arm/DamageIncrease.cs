using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIncrease : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 10;
        this.Sprite_Num = 1;
        this.Skill_Name = "Increase damage";
        this.Skill_Desc = "";
    }
    void Update()
    {
        if(Selected)
        {
            Player_Stat.instance.damage += 5;
            this.Selected = false;
        }
    }
}
