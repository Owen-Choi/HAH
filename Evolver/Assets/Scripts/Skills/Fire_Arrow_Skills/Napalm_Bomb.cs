using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Napalm_Bomb : Skill_Manager
{
    bool isOnce;    bool isSecond;  bool isThird;
    void Start()
    {
        this.Skill_Num = 31;
        this.Skill_Name = "Napalm Bomb";
        //this.Sprite_Num =
        this.Skill_Desc = "+ : ";
        isOnce = false; isSecond = false;   isThird = false;
    }

    
    void Update()
    {
        if (!isOnce && this.Selected_First)
        {
            isOnce = true;
            Player_Stat.instance.burningTime += 1f;
        }

        if(!isSecond && this.Selected_Second)
        {
            isSecond = true;
            Player_Stat.instance.burningTime += 1f;
            Player_Stat.instance.isNapalm2 = true;              //zombie_AI ��ũ��Ʈ���� ���� ���� ���� �� ���ǹ� ����
        }

        if(!isThird && this.Selected_Last)
        {
            isThird = true;
            Player_Stat.instance.Burning_DMG += 2f;
        }
    }
}
