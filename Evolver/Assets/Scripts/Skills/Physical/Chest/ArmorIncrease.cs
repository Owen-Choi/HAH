using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorIncrease : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 21;
        this.Sprite_Num = 24;
        this.Skill_Name = "Increase armor";
        this.Skill_Desc = "";
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.armor += 2.5f;
        }
    }
}
