using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Max_Health_Increase : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 20;
        this.Sprite_Num = 1;
        this.Skill_Name = "최대 체력 증가";
        this.Skill_Desc = "최대 체력 값이 10 증가한다.";
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.DefaultHealthMax += 10;
        }    
    }
}
