using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marathoner : Physical_Manager
{
    
    void Start()
    {
        this.Skill_Num = 7;
        this.Skill_Name = "Marathoner";
        //this.Sprite_Num = 
        this.Skill_Desc = "Your Max Health will be decreased, but your max stamina will be increased and dash cool time will be reduced";
    }

    
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.DefaultHealthMax -= Player_Stat.instance.DefaultHealthMax * 0.05f;         //일단은 5%로 해보자.
            Player_Stat.instance.healthMax -= Player_Stat.instance.DefaultHealthMax * 0.05f;                
            Player_Stat.instance.DefaultStaminaMax += Player_Stat.instance.DefaultStaminaMax * 0.05f;
            Player_Stat.instance.Max_Stamina += Player_Stat.instance.DefaultStaminaMax * 0.05f;             //현재 최대 스테미나에도 늘어난 최대값만큼 값을 추가해주는게 맞음.

            Player_Stat.instance.dashCool -= 5;
        }
    }
}
