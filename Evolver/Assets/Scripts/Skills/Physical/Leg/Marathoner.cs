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
            Player_Stat.instance.DefaultStaminaMax += Player_Stat.instance.DefaultStaminaMax * 0.05f;
            Player_Stat.instance.dashCool -= 5;
        }
    }
}
