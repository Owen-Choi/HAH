using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaRecoveryIncrease :  Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 23;
        //this.Sprite_Num = 
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.Stamina_recovery_speed += 1f;          //수치 조정 가능성 있음.
        }
    }
}
