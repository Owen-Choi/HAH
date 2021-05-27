using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growing : Physical_Manager
{
    int PlayerLevel;
    private void Awake()
    {
        this.Skill_Num = 24;
        this.Sprite_Num = 6;
        PlayerLevel = Player_Stat.instance.Physical_Level;
        this.Skill_Name = "Growing";
        this.Skill_Desc = "Max health will be slightly increased every time when your level up";
    }

    void Update()
    {
        if (this.Selected)
        {
            if(PlayerLevel < Player_Stat.instance.Physical_Level)       //참조 개념이 내가 생각하는 것과 다르다면 동작하지 않을 코드이다.
            {
                PlayerLevel = Player_Stat.instance.Physical_Level;
                Player_Stat.instance.DefaultHealthMax += 3f;           
            }
        }
    }
}
