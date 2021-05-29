using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reinforce_Fast_Twich_Muscle : Physical_Manager
{
    
    void Start()
    {
        this.Skill_Name = "Fast Twitch Muscle Reinforcement";
        this.Skill_Num = 17;
        //this.Sprite_Num = 
        this.Skill_Desc = "Increase Stamina usage, and increase damage, charging speed, arrow's flying speed ";
    }

   
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.Decrease_Stamina_When_Bow_Charge += 2;             //�׽�Ʈ �غ��� ��ġ �����ϱ�
            Player_Stat.instance.damage += 7.5f;
            Player_Stat.instance.ChargingSpeed += 1.2f;
            Player_Stat.instance.launchForce += 5;                                  //���������� ��ġ �����ϱ�
        }
    }
}
