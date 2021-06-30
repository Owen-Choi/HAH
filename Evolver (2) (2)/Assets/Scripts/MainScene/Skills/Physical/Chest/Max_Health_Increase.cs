using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Max_Health_Increase : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 20;
        this.Sprite_Num = 1;
        this.Skill_Name = "�ִ� ü�� ����";
        this.Skill_Desc = "�ִ� ü�� ���� 10 �����Ѵ�.";
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.DefaultHealthMax += 10;
        }    
    }
}
