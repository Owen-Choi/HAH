using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCoolReduce : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 4;
        this.Sprite_Num = 6;
        this.Skill_Name = "질주 쿨타임 감소";
        this.Skill_Desc = "질주의 쿨타임을 5초 감소시킨다.";
        
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            if(Player_Stat.instance.dashCool >= 10)
                Player_Stat.instance.dashCool -= 5;  
        }      
    }
}
