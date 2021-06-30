using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker_Rage : Physical_Manager
{
    bool Berserked;
    public GameObject Player;
    GameObject PlayerCache;
    float DMG_Gap;  float OriginalDMG;

    public GameObject BuffCarrier;
    GameObject BCcache;
    private void Awake()
    {
        this.Skill_Num = 26;
        this.Sprite_Num = 9;
        this.Skill_Name = "폭주";
        this.Skill_Desc = "남은 체력이 전체 체력의 10% 이하일 때 공격력이 대폭 증가한다.";
        PlayerCache = Player;
        BCcache = BuffCarrier;
    }
    private void Update()
    {
        // # 포스트 프로세싱 효과도 더해줄까 고민중
        if (this.Selected)
        {
            if(Player_Stat.instance.health <= Player_Stat.instance.health * 0.1f)
            {
                Berserked = true;
                //Player_Stat.instance.damage *= 2;
                BCcache.GetComponent<Buff_Carrier>().buff_DMG += OriginalDMG;                       //버프받지 않는 능력치를 더해줌. 곱셈으로 처리할 경우 변수가 너무 많아진다.
            }
            // # 한번 폭주상태에 들어갔다가 나왔다면
            if (Berserked && Player_Stat.instance.health > Player_Stat.instance.health * 0.1f)
            {
                Berserked = false;
                //Player_Stat.instance.damage = OriginalDMG;
                BCcache.GetComponent<Buff_Carrier>().buff_DMG -= OriginalDMG;                       //원위치
            }


            if (PlayerCache.layer == LayerMask.NameToLayer("PlayerInShelter"))
                OriginalDMG = Player_Stat.instance.damage;
        }
    }
}
