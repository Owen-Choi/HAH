using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadePercentIncrease : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 1;
        this.Sprite_Num = 2;
        this.Skill_Name = "ȸ���� ����";
        this.Skill_Desc = "ȸ������ ������Ų��. (ȸ���� 5 ����)";
    }
    void Update()
    {
        if (Selected)
        {
            Player_Stat.instance.missPercent += 5;
            this.Selected = false;
        }
    }
}
