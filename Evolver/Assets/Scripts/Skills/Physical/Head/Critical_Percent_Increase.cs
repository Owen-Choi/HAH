using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Critical_Percent_Increase : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 36;
        this.Sprite_Num = 8;
        this.Skill_Name = "치명타 확률 증가";
        this.Skill_Desc = "치명타 발생 확률 5% 증가";
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
