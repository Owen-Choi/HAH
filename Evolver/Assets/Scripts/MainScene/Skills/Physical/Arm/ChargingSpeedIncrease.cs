using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingSpeedIncrease : Physical_Manager
{

    private void Awake()
    {
        this.Skill_Num = 11;
        this.Sprite_Num = 2;
        this.Skill_Name = "��¡�ӵ� ����";
        this.Skill_Desc = "������ ���� ��¡ �ӵ��� ������Ų��. (��¡ �ӵ� 0.35 ����)";
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            if (Player_Stat.instance.ChargingSpeed < 4f)
                Player_Stat.instance.ChargingSpeed += 0.35f;
        }
    }
}
