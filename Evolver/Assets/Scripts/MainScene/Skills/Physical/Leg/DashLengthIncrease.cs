using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashLengthIncrease : Physical_Manager
{
    float DashTime;
    private void Awake()
    {
        this.Skill_Num = 5;
        this.Sprite_Num = 7;
        this.DashTime = Player_Stat.instance.DashTime;
        this.Skill_Name = "질주 거리 증가";
        this.Skill_Desc = "질주 상태의 지속시간을 0.15초 증가시킨다.";
    }

    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            if (this.DashTime < 1.5f)
                Player_Stat.instance.DashTime += 0.15f;
            this.DashTime = Player_Stat.instance.DashTime;
        }
    }
}
