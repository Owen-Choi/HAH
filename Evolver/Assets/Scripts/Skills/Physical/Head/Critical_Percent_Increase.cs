using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Critical_Percent_Increase : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 36;
        this.Sprite_Num = 8;
        this.Skill_Name = "Increase critical attack probability";
        this.Skill_Desc = "";
    }
    private void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.criticalPercent += 5f;
        }
    }
}
