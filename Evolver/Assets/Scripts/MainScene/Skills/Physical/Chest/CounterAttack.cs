using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterAttack : Physical_Manager
{
    bool Damaged;   bool isOnce;
    float OriginalDMG;
    public GameObject Player;
    GameObject PlayerCache;
    public GameObject BuffCarrier;
    GameObject BCcache;
    private void Awake()
    {
        this.Skill_Num = 27;
        this.Sprite_Num = 8;
        this.Skill_Name = "카운터";
        this.Skill_Desc = "적에게 공격을 받은 직후 일시적으로 공격력이 증가한다.";
        PlayerCache = Player;
        OriginalDMG = Player_Stat.instance.damage;
        BCcache = BuffCarrier;
    }
    private void Update()
    {
        if (this.Selected)
        {
            if(PlayerCache.gameObject.layer == LayerMask.NameToLayer("PlayerInShelter"))
            {
                OriginalDMG = Player_Stat.instance.damage;                                                              //혹시라도 쉘터에서 공격력의 변화가 생긴다면 최신화해주기
            }
            else
            {
                if (!isOnce && PlayerCache.gameObject.layer == LayerMask.NameToLayer("Player_Damaged"))                  //플레이어가 피격당하여 피격 레이어에 진입했다면
                {
                    Damaged = true; isOnce = true;
                    //Player_Stat.instance.damage *= 1.4f;
                    BCcache.GetComponent<Buff_Carrier>().buff_DMG += OriginalDMG * 1.4f;
                }
                else if (Damaged && PlayerCache.gameObject.layer != LayerMask.NameToLayer("Player_Damaged"))
                {
                    Damaged = false; isOnce = false;
                    //Player_Stat.instance.damage = OriginalDMG;
                    BCcache.GetComponent<Buff_Carrier>().buff_DMG -= OriginalDMG * 1.4f;
                }
            }
        }
    }
}
