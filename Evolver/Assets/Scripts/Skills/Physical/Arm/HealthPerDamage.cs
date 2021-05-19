using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPerDamage : Physical_Manager
{
    bool isChanged;
    float originalDMG;
    private void Awake()
    {
        this.Skill_Num = 16;
        this.Sprite_Num = 4;
        isChanged = true;
        originalDMG = Player_Stat.instance.damage;
    }
    void Update()
    {
        if (this.Selected && isChanged)
        {
            isChanged = false;
            Player_Stat.instance.DefaultHealthMax += Player_Stat.instance.damage * 0.05f; 
        }

        // # 공격력의 변화가 감지되면 다시 최대체력 업데이트. 이 코드가 동작할 지는 모르겠다.
        if(originalDMG < Player_Stat.instance.damage)
        {
            isChanged = true;         
        }
    }
}
