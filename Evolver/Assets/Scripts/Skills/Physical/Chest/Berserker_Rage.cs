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
        this.Skill_Name = "����";
        this.Skill_Desc = "���� ü���� ��ü ü���� 10% ������ �� ���ݷ��� ���� �����Ѵ�.";
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
            // # �ѹ� ���ֻ��¿� ���ٰ� ���Դٸ�
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
