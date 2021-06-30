using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambidextrous : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 15;
        this.Sprite_Num = 8;
        this.Skill_Name = "양손잡이";
        this.Skill_Desc = "공격력이 30% 감소하지만 차징속도가 대폭 증가한다.";
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.damage -= Player_Stat.instance.damage * 0.3f;      // 데미지 30% 감소
            Player_Stat.instance.ChargingSpeed += 3f;                               // 차징 속도 대폭 증가
        }
    }
}
