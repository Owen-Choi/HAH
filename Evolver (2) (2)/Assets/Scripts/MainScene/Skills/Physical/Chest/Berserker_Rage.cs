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
        this.Skill_Name = "����";
        this.Skill_Desc = "���� ü���� ��ü ü���� 10% ������ �� ���ݷ��� ���� �����Ѵ�.";
        PlayerCache = Player;
        BCcache = BuffCarrier;
    }
    private void Update()
    {
        // # ����Ʈ ���μ��� ȿ���� �����ٱ� �����
        if (this.Selected)
        {
            if(Player_Stat.instance.health <= Player_Stat.instance.health * 0.1f)
            {
                Berserked = true;
                //Player_Stat.instance.damage *= 2;
                BCcache.GetComponent<Buff_Carrier>().buff_DMG += OriginalDMG;                       //�������� �ʴ� �ɷ�ġ�� ������. �������� ó���� ��� ������ �ʹ� ��������.
            }
            // # �ѹ� ���ֻ��¿� ���ٰ� ���Դٸ�
            if (Berserked && Player_Stat.instance.health > Player_Stat.instance.health * 0.1f)
            {
                Berserked = false;
                //Player_Stat.instance.damage = OriginalDMG;
                BCcache.GetComponent<Buff_Carrier>().buff_DMG -= OriginalDMG;                       //����ġ
            }


            if (PlayerCache.layer == LayerMask.NameToLayer("PlayerInShelter"))
                OriginalDMG = Player_Stat.instance.damage;
        }
    }
}
