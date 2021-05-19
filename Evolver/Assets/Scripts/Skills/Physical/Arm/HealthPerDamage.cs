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

        // # ���ݷ��� ��ȭ�� �����Ǹ� �ٽ� �ִ�ü�� ������Ʈ. �� �ڵ尡 ������ ���� �𸣰ڴ�.
        if(originalDMG < Player_Stat.instance.damage)
        {
            isChanged = true;         
        }
    }
}
