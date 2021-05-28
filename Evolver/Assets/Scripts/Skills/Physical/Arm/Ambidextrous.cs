using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambidextrous : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 15;
        //this.Sprite_Num =
        this.Skill_Name = "Ambidextrous";
        this.Skill_Desc = "Decrease damage value as 30%, and Increase charging speed very high";
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.damage -= Player_Stat.instance.damage * 0.3f;      // ������ 30% ����
            Player_Stat.instance.ChargingSpeed += 3f;                               // ��¡ �ӵ� ���� ����
        }
    }
}
