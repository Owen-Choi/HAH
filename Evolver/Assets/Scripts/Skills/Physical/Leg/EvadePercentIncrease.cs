using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadePercentIncrease : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 1;
        this.Sprite_Num = 16;
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
