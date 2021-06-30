using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marathoner : Physical_Manager
{
    
    void Start()
    {
        this.Skill_Num = 7;
        this.Skill_Name = "�������";
        this.Sprite_Num = 9;
        this.Skill_Desc = "�ִ� ü���� 5% ���ҽ�Ű�� �ִ� ���׹̳��� 5% ������Ų��. ���� ������ ��Ÿ���� 5�� ���ҽ�Ų��.";
    }

    
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.DefaultHealthMax -= Player_Stat.instance.DefaultHealthMax * 0.05f;         //�ϴ��� 5%�� �غ���.
            Player_Stat.instance.healthMax -= Player_Stat.instance.DefaultHealthMax * 0.05f;                
            Player_Stat.instance.DefaultStaminaMax += Player_Stat.instance.DefaultStaminaMax * 0.05f;
            Player_Stat.instance.Max_Stamina += Player_Stat.instance.DefaultStaminaMax * 0.05f;             //���� �ִ� ���׹̳����� �þ �ִ밪��ŭ ���� �߰����ִ°� ����.
            if(Player_Stat.instance.dashCool > 10f)
                Player_Stat.instance.dashCool -= 5;
        }
    }
}
