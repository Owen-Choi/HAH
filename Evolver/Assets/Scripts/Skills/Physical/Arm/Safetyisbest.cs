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
        this.Skill_Name = "��������";
        this.Skill_Desc = "���ݷ��� 10% �����ϰ�, ������ ��ġ��ŭ ������ �����Ѵ�.";
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
