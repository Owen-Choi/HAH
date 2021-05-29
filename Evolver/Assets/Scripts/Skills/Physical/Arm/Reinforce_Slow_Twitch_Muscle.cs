using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reinforce_Slow_Twitch_Muscle : Physical_Manager
{
    
    void Start()
    {
        this.Skill_Num = 18;
        this.Skill_Name = "Slow Twitch Muscle Reinforcement";
        //this.Sprite_Num =
        this.Skill_Desc = "Decrease stamina usage and decrease damage, charging speed, arrow's flying speed";
    }

    
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.Decrease_Stamina_When_Bow_Charge -= 2f;
            Player_Stat.instance.damage -= 5f;
            Player_Stat.instance.ChargingSpeed -= 1f;
            Player_Stat.instance.launchForce -= 3.5f;
        }
    }
}
