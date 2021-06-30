using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorIncrease : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 21;
        this.Sprite_Num = 2;
        this.Skill_Name = "방어력 증가";
        this.Skill_Desc = "방어력을 증가시킨다.(방어력 2.5 증가)";
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
