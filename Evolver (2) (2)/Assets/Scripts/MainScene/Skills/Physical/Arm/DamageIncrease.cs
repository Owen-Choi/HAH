using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIncrease : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 10;
        this.Sprite_Num = 1;
        this.Skill_Name = "공격력 증가";
        this.Skill_Desc = "공격력을 증가시킨다. (공격력 수치 5 증가)";
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
