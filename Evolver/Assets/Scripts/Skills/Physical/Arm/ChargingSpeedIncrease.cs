using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingSpeedIncrease : Physical_Manager
{

    private void Awake()
    {
        this.Skill_Num = 11;
        this.Sprite_Num = 2;
        this.Skill_Name = "Increase charging speed";
        this.Skill_Desc = "";
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            if (Player_Stat.instance.ChargingSpeed < 8f)
                Player_Stat.instance.ChargingSpeed += 1f;
        }
    }
}
