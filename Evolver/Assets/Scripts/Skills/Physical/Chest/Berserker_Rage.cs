using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker_Rage : Physical_Manager
{
    bool Berserked;
    float OriginalDMG;

    private void Awake()
    {
        this.Skill_Num = 26;
        this.Sprite_Num = 9;
        this.Skill_Name = "Berserker rage";
        this.Skill_Desc = "pump damage when your health is less than 10%";
    }
    private void Update()
    {
        if (this.Selected)
        {
            if(Player_Stat.instance.health <= Player_Stat.instance.health * 0.1f)
            {
                Berserked = true;
                OriginalDMG = Player_Stat.instance.damage;
                Player_Stat.instance.damage *= 2;
            }
            // # �ѹ� ���ֻ��¿� ���ٰ� ���Դٸ�
            else if (Berserked)
            {
                Berserked = false;
                Player_Stat.instance.damage = OriginalDMG;
            }
        }
    }
}
