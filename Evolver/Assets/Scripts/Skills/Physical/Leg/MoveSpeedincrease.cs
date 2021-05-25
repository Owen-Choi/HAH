using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedincrease : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 0;
        this.Sprite_Num = 15;
        this.Skill_Name = "Increase movement speed";
        this.Skill_Desc = "";
    }
    void Update()
    {
        if (Selected)
        {
            Player_Stat.instance.moveSpeed += 0.5f;
            this.Selected = false;
        }    
    }
}
