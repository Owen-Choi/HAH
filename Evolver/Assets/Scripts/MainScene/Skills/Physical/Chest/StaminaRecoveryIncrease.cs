using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaRecoveryIncrease :  Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 23;
        this.Sprite_Num = 7;
        this.Skill_Name = "스테미나 회복속도 증가";
        this.Skill_Desc = "스테미나의 회복 속도가 1 증가한다.";
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
