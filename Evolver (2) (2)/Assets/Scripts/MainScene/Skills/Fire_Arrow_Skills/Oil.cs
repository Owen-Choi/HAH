using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : Skill_Manager
{
    bool ChangeOnce;    bool ChangeTwice;
    // Start is called before the first frame update
    void Start()
    {
        this.Skill_Num = 25;
        ChangeOnce = false;
        ChangeTwice = false;
        this.Sprite_Num = 13;
        this.Skill_Name = "기름";
        this.Skill_Desc = "적에게 화상을 입힐 확률이 20% 증가한다.";
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Selected_First && !ChangeOnce)
        {
            Player_Stat.instance.Burn_Percent += 20f;
            ChangeOnce = true;
            this.Sprite_Num = 14;
            this.Skill_Desc = "적에게 화상을 입힐 확률이 20% 증가한다.";
        }
        if (this.Selected_Second && !ChangeTwice)
        {
            Player_Stat.instance.Burn_Percent += 20f;
            ChangeTwice = true;
            this.Sprite_Num = 15;
            this.Skill_Desc = "모든 공격이 적에게 화상을 입힌다.";
        }
        if(this.Selected_Last)
        {
            this.Selected = true;
            Player_Stat.instance.Burn_Percent = 100f;
            return;
        }
        
    }
}
