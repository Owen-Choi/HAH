using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Max_Stamina_Increase : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 22;
        this.Sprite_Num = 25;
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.DefaultStaminaMax += 5;
        }       
    }
}
