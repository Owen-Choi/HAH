using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamPack : Physical_Manager
{
    private bool Selected_Once;

    private void Awake()
    {
        this.Skill_Num = 3;
        this.Sprite_Num = 5;
        this.Skill_Name = "스팀팩";
        this.Skill_Desc = "최대 체력의 수치를 감소시키고 이동 속도와 차징 속도를 증가시킨다. (최대 체력 5% 감소, 차징속도와 이동속도 0.5 증가)";
    }
    private void Update()
    {
        if(this.Selected && !this.Selected_Once)
        {
            this.Selected = false;
            this.Selected_Once = true;
            // # 최대체력 5퍼센트 감소(수치 조정 가능), 이동속도, 차징속도 증가
            if(Player_Stat.instance.DefaultHealthMax > 60f)
                Player_Stat.instance.DefaultHealthMax -= Player_Stat.instance.DefaultHealthMax * 0.05f;
            if(Player_Stat.instance.moveSpeed < 10f)
                Player_Stat.instance.moveSpeed += 0.5f;
            if (Player_Stat.instance.ChargingSpeed < 8f)
                Player_Stat.instance.ChargingSpeed += 0.5f;
        }
    }
}
