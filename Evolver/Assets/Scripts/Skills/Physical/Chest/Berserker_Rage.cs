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
        //this.Sprite_Num = 
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
            // # 한번 폭주상태에 들어갔다가 나왔다면
            else if (Berserked)
            {
                Berserked = false;
                Player_Stat.instance.damage = OriginalDMG;
            }
        }
    }
}
