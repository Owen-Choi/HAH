using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualCore : Physical_Manager
{
    int PlayerLevel;
    private void Awake()
    {
        PlayerLevel = Player_Stat.instance.Physical_Level;
        this.Skill_Num = 25;
        this.Sprite_Num = 4;
        this.Skill_Name = "두개의 심장";
        this.Skill_Desc = "플레이어의 신체 레벨이 오를 때 마다 최대 스테미나 값이 1.5씩 증가한다.";
    }
    private void Update()
    {
        if (this.Selected)
        {
            if (PlayerLevel < Player_Stat.instance.Physical_Level)
            {
                PlayerLevel = Player_Stat.instance.Physical_Level;
                Player_Stat.instance.DefaultStaminaMax += 1.5f;
            }
        }        
    }
}
