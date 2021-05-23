using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Max_Health_Increase : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 20;
        this.Sprite_Num = 23;
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.DefaultHealthMax += 20;
        }    
    }
}
