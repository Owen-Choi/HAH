using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingSpeedIncrease : Physical_Manager
{

    private void Awake()
    {
        this.Skill_Num = 11;
        this.Sprite_Num = 2;
        this.Skill_Name = "차징속도 증가";
        this.Skill_Desc = "수련을 통해 차징 속도를 증가시킨다. (차징 속도 0.35 증가)";
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            if (Player_Stat.instance.ChargingSpeed < 4f)
                Player_Stat.instance.ChargingSpeed += 0.35f;
        }
    }
}
