using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safetyisbest : Physical_Manager
{
    float decValue;

    private void Awake()
    {
        this.Skill_Num = 14;
        this.Sprite_Num = 5;
        this.Skill_Name = "안전제일";
        this.Skill_Desc = "공격력이 10% 감소하고, 감소한 수치만큼 방어력이 증가한다.";
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            decValue = Player_Stat.instance.damage * 0.1f;
            Player_Stat.instance.damage -= decValue;
            Player_Stat.instance.armor += decValue;
        }       
    }
}
