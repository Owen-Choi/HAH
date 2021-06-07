using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedincrease : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 0;
        this.Sprite_Num = 1;
        this.Skill_Name = "이동속도 증가";
        this.Skill_Desc = "이동속도를 증가시킨다. (이동 속도 0.25 증가)";
    }
    void Update()
    {
        if (Selected)
        {
            Player_Stat.instance.moveSpeed += 0.25f;
            this.Selected = false;
        }    
    }
}
