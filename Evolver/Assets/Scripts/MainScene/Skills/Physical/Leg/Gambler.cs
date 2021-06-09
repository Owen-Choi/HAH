using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gambler : Physical_Manager
{
    private bool Selected_Once;


    private void Awake()
    {
        this.Skill_Num = 2;
        this.Sprite_Num = 4;
        this.Skill_Name = "승부사";
        this.Skill_Desc = "회피 확률을 30% 증가시키고 최대 체력을 30% 깎는다.";
    }
    private void Update()
    {
        if(this.Selected && !this.Selected_Once)
        {
            // # 회피확률 30퍼 증가, 최대체력 20퍼 감소
            this.Selected = false;
            this.Selected_Once = true;
            Player_Stat.instance.missPercent += 30;
            Player_Stat.instance.DefaultHealthMax -= Player_Stat.instance.DefaultHealthMax * 0.3f;
        }
    }
}
