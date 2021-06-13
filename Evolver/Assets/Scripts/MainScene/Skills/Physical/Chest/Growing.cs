using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growing : Physical_Manager
{
    int PlayerLevel;
    private void Awake()
    {
        this.Skill_Num = 24;
        this.Sprite_Num = 6;
        PlayerLevel = Player_Stat.instance.Physical_Level;
        this.Skill_Name = "�ڶ󳪴� ����";
        this.Skill_Desc = "�÷��̾��� ��ü ������ ���� �� ���� ü���� �ִ� ���� 2�� �����Ѵ�.";
    }

    void Update()
    {
        if (this.Selected)
        {
            if(PlayerLevel < Player_Stat.instance.Physical_Level)       //���� ������ ���� �����ϴ� �Ͱ� �ٸ��ٸ� �������� ���� �ڵ��̴�.
            {
                PlayerLevel = Player_Stat.instance.Physical_Level;
                Player_Stat.instance.DefaultHealthMax += 2f;           
            }
        }
    }
}