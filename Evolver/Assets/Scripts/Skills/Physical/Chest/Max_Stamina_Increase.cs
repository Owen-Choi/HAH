using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Max_Stamina_Increase : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 22;
        this.Sprite_Num = 3;
        this.Skill_Name = "최대 스테미나 증가";
        this.Skill_Desc = "최대 스테미나 값이 5 증가한다.";
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
