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
        this.Sprite_Num = 5;
        OnlyOnce = false;
        this.Skill_Name = "Feather";
        this.Skill_Desc = "your movement speed will increase as 10 percent of dodge percent, and your max health will be decreased as 10 percent";
    }


    private void Update()
    {
        if(this.Selected_First && !OnlyOnce)
        {
            OnlyOnce = true;
            this.Selected = true;
            Temp = (float)Player_Stat.instance.missPercent / 10;
            Player_Stat.instance.moveSpeed += Temp;
            Player_Stat.instance.health = Player_Stat.instance.health - (float)Player_Stat.instance.health / 10;
            return;
        }
    }

}
