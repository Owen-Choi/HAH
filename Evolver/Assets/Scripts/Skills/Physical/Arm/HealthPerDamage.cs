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
        this.Sprite_Num = 6;
        isChanged = true;
        originalDMG = Player_Stat.instance.damage;
        this.Skill_Name = "Viking";
        this.Skill_Desc = "Increase health as 5 percent of damage";
    }
    void Update()
    {
        // ��ȸ������ ȿ���� ��� ���ӵ��� �ʰ� �ؾ߰ڴ�.
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.DefaultHealthMax += Player_Stat.instance.damage * 0.05f; 
        }

    }
}
