using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker_Rage : Physical_Manager
{
    bool Berserked;
    float OriginalDMG;
    public GameObject Player;
    GameObject PlayerCache;
    private void Awake()
    {
        this.Skill_Num = 26;
        this.Sprite_Num = 9;
        this.Skill_Name = "폭주";
        this.Skill_Desc = "남은 체력이 전체 체력의 10% 이하일 때 공격력이 대폭 증가한다.";
        OriginalDMG = Player_Stat.instance.damage;
        PlayerCache = Player;
    }
    private void Update()
    {
        if (this.Selected)
        {
            if(Player_Stat.instance.health <= Player_Stat.instance.health * 0.1f)
            {
                Berserked = true;
                Player_Stat.instance.damage *= 2;
            }
            // # 한번 폭주상태에 들어갔다가 나왔다면
            if (Berserked && Player_Stat.instance.health > Player_Stat.instance.health * 0.1f)
            {
                Berserked = false;
                Player_Stat.instance.damage = OriginalDMG;
            }


            if (PlayerCache.layer == LayerMask.NameToLayer("PlayerInShelter"))
                OriginalDMG = Player_Stat.instance.damage;
        }
    }
}
