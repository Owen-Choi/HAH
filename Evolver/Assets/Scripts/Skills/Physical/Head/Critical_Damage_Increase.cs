using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Critical_Damage_Increase : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 35;
        this.Sprite_Num = 7;
        this.Skill_Name = "치명타 피해량 증가";
        this.Skill_Desc = "치명타 피해량이 증가한다. (치명타 피해량 20% 증가 )";
    }
    private void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.criticalDamage += 20f;     //수치 조정 가능성 높음
        }
    }
}
