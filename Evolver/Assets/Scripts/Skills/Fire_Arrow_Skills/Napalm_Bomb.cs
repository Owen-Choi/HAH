using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Napalm_Bomb : Skill_Manager
{
    bool isOnce;    bool isSecond;  bool isThird;
    void Start()
    {
        this.Skill_Num = 31;
        this.Skill_Name = "네이팜 탄";
        //this.Sprite_Num =
        this.Skill_Desc = "화상의 지속시간이 증가한다.";
        isOnce = false; isSecond = false;   isThird = false;
    }

    
    void Update()
    {
        if (!isOnce && this.Selected_First)
        {
            isOnce = true;
            Player_Stat.instance.burningTime += 1f;
            this.Skill_Desc = "화상의 지속시간이 증가하며 화상상태에서 적의 이동속도가 감소한다.";
        }

        if(!isSecond && this.Selected_Second)
        {
            isSecond = true;
            Player_Stat.instance.burningTime += 1f;
            Player_Stat.instance.isNapalm2 = true;              //zombie_AI 스크립트에서 관련 변수 참조 후 조건문 적용
            this.Skill_Desc = "화상의 피해량이 대폭 증가한다.";
        }

        if(!isThird && this.Selected_Last)
        {
            isThird = true;
            Player_Stat.instance.Burning_DMG += 10f;
        }
    }
}
