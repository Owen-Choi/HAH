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
        this.Skill_Name = "ī����";
        this.Skill_Desc = "������ ������ ���� ���� �Ͻ������� ���ݷ��� �����Ѵ�.";
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
                OriginalDMG = Player_Stat.instance.damage;                                                              //Ȥ�ö� ���Ϳ��� ���ݷ��� ��ȭ�� ����ٸ� �ֽ�ȭ���ֱ�
            }
            else
            {
                if (!isOnce && PlayerCache.gameObject.layer == LayerMask.NameToLayer("Player_Damaged"))                  //�÷��̾ �ǰݴ��Ͽ� �ǰ� ���̾ �����ߴٸ�
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
