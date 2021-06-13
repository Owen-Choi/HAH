using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorIncrease : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 21;
        this.Sprite_Num = 2;
        this.Skill_Name = "���� ����";
        this.Skill_Desc = "������ ������Ų��.(���� 2.5 ����)";
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.armor += 2.5f;
        }
    }
}