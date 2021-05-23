using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingShot : Skill_Manager         //��¡ �� �̵��ӵ� ���� ������� �����
{

    private void Start()
    {
        this.Skill_Num = 1;
        this.Sprite_Num = 36;
        this.Skill_Name = "Moving Shot";
        this.Skill_Desc = "Movement speed will not decrease when you charging attack";
    }

    private void Update()
    {
        if(this.Selected_First)
        {
            this.Selected = true;
            Player_Stat.instance.SlowForCharge = 1f;
            return;
        }
    }
}
