using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashLengthIncrease : Physical_Manager
{
    float DashTime;
    private void Awake()
    {
        this.Skill_Num = 5;
        this.Sprite_Num = 7;
        this.DashTime = Player_Stat.instance.DashTime;
        this.Skill_Name = "Increase dash distance";
        this.Skill_Desc = "";
    }

    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            if (this.DashTime < 1.5f)
                Player_Stat.instance.DashTime += 0.15f;
            this.DashTime = Player_Stat.instance.DashTime;
        }
    }
}
