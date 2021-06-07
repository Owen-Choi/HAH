using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reinforce_Fast_Twich_Muscle : Physical_Manager
{
    
    void Start()
    {
        this.Skill_Name = "속근 강화";
        this.Skill_Num = 17;
        this.Sprite_Num = 9;
        this.Skill_Desc = "스테미나 사용량이 증가하는 대신 공격력, 차징속도, 투사체 속도가 증가한다. (스테미나 사용량 2 증가, 공격력 7.5 증가, 차징속도 0.65 증가, 투사체 속도 3 증가)";
    }

   
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.Decrease_Stamina_When_Bow_Charge += 2;             //테스트 해보고 수치 조정하기
            Player_Stat.instance.damage += 7.5f;
            Player_Stat.instance.ChargingSpeed += 0.65f;
            Player_Stat.instance.launchForce += 3;                                  //마찬가지로 수치 조정하기
        }
    }
}
