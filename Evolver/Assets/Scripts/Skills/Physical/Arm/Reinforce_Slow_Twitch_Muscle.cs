using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reinforce_Slow_Twitch_Muscle : Physical_Manager
{
    
    void Start()
    {
        this.Skill_Num = 18;
        this.Skill_Name = "���� ��ȭ";
        //this.Sprite_Num =
        this.Skill_Desc = "���׹̳� ��뷮�� �����ϴ� ��� ���ݷ�, ��¡�ӵ�, ����ü �ӵ��� �����Ѵ�. (���׹̳� ��뷮 2 ����, ���ݷ� 5 ����, ��¡�ӵ� 0.5 ����, ����ü �ӵ� 2.5 ����)";
    }

    
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.Decrease_Stamina_When_Bow_Charge -= 2f;
            Player_Stat.instance.damage -= 5f;
            Player_Stat.instance.ChargingSpeed -= 0.5f;
            Player_Stat.instance.launchForce -= 2.5f;
        }
    }
}
