using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_is_the_Best_Defence : Physical_Manager
{

    private void Awake()
    {
        this.Skill_Num = 28;
        this.Sprite_Num = 9;
        this.Skill_Name = "Attack is the best defence ";
        this.Skill_Desc = "Increase damage as defence value ";
    }
    private void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.damage += 5f;
            Player_Stat.instance.armor -= 5f;
            // 수치 조정해야할 수도 있다.
        }
    }
}
