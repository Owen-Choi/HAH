using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterAttack : Physical_Manager
{
    bool Damaged;   bool isOnce;
    float OriginalDMG;
    public GameObject Player;
    GameObject PlayerCache;

    private void Awake()
    {
        this.Skill_Num = 27;
        this.Sprite_Num = 8;
        this.Skill_Name = "Counter Attack";
        this.Skill_Desc = "Damage will be increased temporarily if you are attacked";
        PlayerCache = Player;
        OriginalDMG = Player_Stat.instance.damage;
    }
    private void Update()
    {
        if (this.Selected)
        {
            if(PlayerCache.gameObject.layer == LayerMask.NameToLayer("PlayerInShelter"))
            {
                OriginalDMG = Player_Stat.instance.damage;              //Ȥ�ö� ���Ϳ��� ���ݷ��� ��ȭ�� ����ٸ� �ֽ�ȭ���ֱ�
            }
            else
            {
                if (!isOnce && PlayerCache.gameObject.layer == LayerMask.NameToLayer("Player_Damaged"))                  //�÷��̾ �ǰݴ��Ͽ� �ǰ� ���̾ �����ߴٸ�
                {
                    Damaged = true; isOnce = true;
                    Player_Stat.instance.damage *= 1.4f;
                }
                else if (PlayerCache.gameObject.layer == LayerMask.NameToLayer("Player") && Damaged)
                {
                    Damaged = false; isOnce = false;
                    Player_Stat.instance.damage = OriginalDMG;
                }
            }
        }
    }
}
