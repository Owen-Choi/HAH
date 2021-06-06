using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPerDamage : Physical_Manager
{
    bool isChanged;
    float originalDMG;
    private void Awake()
    {
        this.Skill_Num = 16;
        //this.Sprite_Num = 6;
        isChanged = true;
        originalDMG = Player_Stat.instance.damage;
        this.Skill_Name = "바이킹";
        this.Skill_Desc = "공격력의 5퍼센트 만큼 최대 체력을 증가시킨다.";
    }
    void Update()
    {
        // 일회성으로 효과가 계속 지속되지 않게 해야겠다.
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.DefaultHealthMax += Player_Stat.instance.damage * 0.05f; 
        }

    }
}
