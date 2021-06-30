using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : Skill_Manager        //회피율의 10%만큼 이동속도 증가, 최대체력 10% 감소
{
    bool OnlyOnce;
    float Temp;
    private void Start()
    {
        this.Skill_Num = 2;
        this.Sprite_Num = 3;
        OnlyOnce = false;
        this.Skill_Name = "깃털";
        this.Skill_Desc = "최대체력이 10% 감소하지만 회피율의 10%만큼 이동속도가 증가한다.";
    }


    private void Update()
    {
        if(this.Selected_First && !OnlyOnce)
        {
            OnlyOnce = true;
            this.Selected = true;
            Temp = (float)Player_Stat.instance.missPercent / 10;
            Player_Stat.instance.moveSpeed += Temp;
            Player_Stat.instance.DefaultHealthMax = Player_Stat.instance.DefaultHealthMax - (float)Player_Stat.instance.DefaultHealthMax * 0.1f;
            return;
        }
    }

}
