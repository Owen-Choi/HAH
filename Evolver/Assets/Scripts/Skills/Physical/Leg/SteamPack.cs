using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamPack : Physical_Manager
{
    private bool Selected_Once;

    private void Awake()
    {
        this.Skill_Num = 3;
        this.Sprite_Num = 19;
        this.Skill_Name = "Steampack";
        this.Skill_Desc = "Increase movement speed and charging speed, but decrease max health as 5% ";
    }
    private void Update()
    {
        if(this.Selected && !this.Selected_Once)
        {
            this.Selected = false;
            this.Selected_Once = true;
            // # �ִ�ü�� 5�ۼ�Ʈ ����(��ġ ���� ����), �̵��ӵ�, ��¡�ӵ� ����
            if(Player_Stat.instance.DefaultHealthMax > 60f)
                Player_Stat.instance.DefaultHealthMax -= Player_Stat.instance.DefaultHealthMax * 0.05f;
            if(Player_Stat.instance.moveSpeed < 10f)
                Player_Stat.instance.moveSpeed += 1f;
            if (Player_Stat.instance.ChargingSpeed < 8f)
                Player_Stat.instance.ChargingSpeed += 0.5f;
        }
    }
}
