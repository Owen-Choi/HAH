using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadePercentIncrease : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 1;
        this.Sprite_Num = 2;
        this.Skill_Name = "회피율 증가";
        this.Skill_Desc = "회피율을 증가시킨다. (회피율 5 증가)";
    }
    void Update()
    {
        if (Selected)
        {
            Player_Stat.instance.missPercent += 5;
            this.Selected = false;
        }
    }
}
