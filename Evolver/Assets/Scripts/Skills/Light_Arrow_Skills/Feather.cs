using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : Skill_Manager        //회피율의 10%만큼 이동속도 증가, 최대체력 10% 감소
{
    float Temp;
    private void Start()
    {
        this.Skill_Num = 2;
    }


    private void Update()
    {
        if(this.Selected)
        {
            Temp = (float)Player_Stat.instance.missPercent / 10;
            Player_Stat.instance.moveSpeed += Temp;
            Player_Stat.instance.health = Player_Stat.instance.health - (float)Player_Stat.instance.health / 10;
            return;
        }
    }

}
