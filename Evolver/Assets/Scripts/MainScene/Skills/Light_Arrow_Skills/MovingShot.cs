using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingShot : Skill_Manager         //차징 시 이동속도 감소 디버프가 사라짐
{

    private void Start()
    {
        this.Skill_Num = 1;
        this.Sprite_Num = 10;
        this.Skill_Name = "기동사격";
        this.Skill_Desc = "시위를 당기고 있어도 이동속도가 줄어들지 않는다.";
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
