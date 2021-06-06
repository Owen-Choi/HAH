using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reinforce_Slow_Twitch_Muscle : Physical_Manager
{
    
    void Start()
    {
        this.Skill_Num = 18;
        this.Skill_Name = "지근 강화";
        //this.Sprite_Num =
        this.Skill_Desc = "스테미나 사용량이 감소하는 대신 공격력, 차징속도, 투사체 속도가 감소한다. (스테미나 사용량 2 감소, 공격력 5 감소, 차징속도 0.5 감소, 투사체 속도 2.5 감소)";
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
