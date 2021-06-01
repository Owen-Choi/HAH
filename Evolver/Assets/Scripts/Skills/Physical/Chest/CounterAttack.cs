using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterAttack : Physical_Manager
{
    bool Damaged;   bool isOnce;
    float OriginalDMG;  float DefaultDMG;
    public GameObject Player;
    GameObject PlayerCache;

    private void Awake()
    {
        this.Skill_Num = 27;
        this.Sprite_Num = 8;
        this.Skill_Name = "Counter Attack";
        this.Skill_Desc = "Damage will be increased temporarily if you are attacked";
        PlayerCache = Player;
        OriginalDMG = DefaultDMG = Player_Stat.instance.damage;
    }
    private void Update()
    {
        if (this.Selected)
        {
            if(!isOnce && PlayerCache.gameObject.layer == LayerMask.NameToLayer("Player_Damaged"))                  //플레이어가 피격당하여 피격 레이어에 진입했다면
            {
                Damaged = true; isOnce = true;
                OriginalDMG = Player_Stat.instance.damage;
                Player_Stat.instance.damage *= 1.4f;   
            }
            else if(PlayerCache.gameObject.layer == LayerMask.NameToLayer("Player") && Damaged)
            {
                Damaged = false;    isOnce = false;
                if (DefaultDMG != OriginalDMG)
                    Player_Stat.instance.damage = OriginalDMG;
                else
                    Player_Stat.instance.damage = DefaultDMG;
            }


            if(PlayerCache.gameObject.layer == LayerMask.NameToLayer("PlayerInShelter"))
            {
                DefaultDMG = OriginalDMG = Player_Stat.instance.damage;              //혹시라도 쉘터에서 공격력의 변화가 생긴다면 최신화해주기
            }
        }
    }
}
