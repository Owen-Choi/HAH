using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continued_Shot : Skill_Manager
{
    bool DMG_Decrease_Once;
    bool DMG_Decrease_Twice;
    bool DMG_Increase_First;
    private void Start()
    {
        this.DMG_Decrease_Once = false;
        this.DMG_Decrease_Twice = false;
        this.DMG_Increase_First = false;
        this.Skill_Num = 4;
        this.Sprite_Num = 4;
        this.Skill_Name = "���ӻ��";
        this.Skill_Desc = "����� ���� �� ��ٷ� �ѹ� �� ����Ѵ�. ���ݷ��� 3 �����Ѵ�.";
    }

   

    void Update()
    {
        if (this.Selected_First)
            if (!DMG_Decrease_Once)
            {
                DMG_Decrease_Once = true;
                this.Sprite_Num = 5;
                Player_Stat.instance.is_Continued_Shot = true;
                Player_Stat.instance.damage -= 3;               //���� ��ġ �����ϱ�
                this.Skill_Desc = "����� ���� �� ��ٷ� �ѹ� �� ����Ѵ�. ���ݷ��� 2 �����Ѵ�.";
            }
            

        if (this.Selected_Second)
            if (!DMG_Decrease_Twice)
            {
                this.Sprite_Num = 6;
                DMG_Decrease_Twice = true;
                Player_Stat.instance.is_Continued_Shot2 = true;
                Player_Stat.instance.damage -= 2;               //���� ��ġ �����ϱ�
                this.Skill_Desc = "���ݷ��� 5 ������Ų��.";
            }
        

        if(this.Selected_Last && !DMG_Increase_First)
        {
            this.Selected = true;
            DMG_Increase_First = true;
            Player_Stat.instance.damage += 5;                   //���� ��ġ �����ϱ�
            this.GetComponent<Continued_Shot>().enabled = false;
            return;
        }
    }
}
