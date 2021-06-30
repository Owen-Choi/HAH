using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIncrease : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 10;
        this.Sprite_Num = 1;
        this.Skill_Name = "���ݷ� ����";
        this.Skill_Desc = "���ݷ��� ������Ų��. (���ݷ� ��ġ 5 ����)";
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
