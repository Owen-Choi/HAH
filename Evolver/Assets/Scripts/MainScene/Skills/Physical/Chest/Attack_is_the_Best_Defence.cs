using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_is_the_Best_Defence : Physical_Manager
{

    private void Awake()
    {
        this.Skill_Num = 28;
        this.Sprite_Num = 5;
        this.Skill_Name = "�ּ��� ���� ����";
        this.Skill_Desc = "������ ��� ���ݷ��� ������Ų��. (���� 5 ����, ���ݷ� 7 ����)";
    }
    private void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.damage += 7f;
            Player_Stat.instance.armor -= 5f;
            // ��ġ �����ؾ��� ���� �ִ�.
        }
    }
}
