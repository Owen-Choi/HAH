using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterAttack : Physical_Manager
{
    bool Damaged;
    float tempDMG;
    public GameObject Player;

    private void Awake()
    {
        this.Skill_Num = 27;
        this.Sprite_Num = 7;
        this.Skill_Name = "Counter Attack";
        this.Skill_Desc = "Damage will be increased temporarily if you are attacked";
    }
    private void Update()
    {
        if (this.Selected)
        {
            if(Player.gameObject.layer == LayerMask.NameToLayer("Player_Damaged"))                  //�÷��̾ �ǰݴ��Ͽ� �ǰ� ���̾ �����ߴٸ�
            {
                Damaged = true;
                tempDMG = Player_Stat.instance.damage;
                Player_Stat.instance.damage *= 1.4f;   
            }
            else if(Player.gameObject.layer == LayerMask.NameToLayer("Player") && Damaged)
            {
                Damaged = false;
                Player_Stat.instance.damage = tempDMG;
            }


            if(Player.gameObject.layer == LayerMask.NameToLayer("PlayerInShelter"))
            {
                tempDMG = Player_Stat.instance.damage;              //Ȥ�ö� ���Ϳ��� ���ݷ��� ��ȭ�� ����ٸ� �ֽ�ȭ���ֱ�
            }
        }
    }
}
