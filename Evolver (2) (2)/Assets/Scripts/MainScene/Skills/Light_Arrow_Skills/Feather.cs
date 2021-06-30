using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : Skill_Manager        //ȸ������ 10%��ŭ �̵��ӵ� ����, �ִ�ü�� 10% ����
{
    bool OnlyOnce;
    float Temp;
    private void Start()
    {
        this.Skill_Num = 2;
        this.Sprite_Num = 3;
        OnlyOnce = false;
        this.Skill_Name = "����";
        this.Skill_Desc = "�ִ�ü���� 10% ���������� ȸ������ 10%��ŭ �̵��ӵ��� �����Ѵ�.";
    }


    private void Update()
    {
        if(this.Selected_First && !OnlyOnce)
        {
            OnlyOnce = true;
            this.Selected = true;
            Temp = (float)Player_Stat.instance.missPercent / 10;
            Player_Stat.instance.moveSpeed += Temp;
            Player_Stat.instance.DefaultHealthMax = Player_Stat.instance.DefaultHealthMax - (float)Player_Stat.instance.DefaultHealthMax * 0.1f;
            return;
        }
    }

}
