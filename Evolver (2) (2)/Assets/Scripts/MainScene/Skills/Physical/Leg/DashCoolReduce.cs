using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCoolReduce : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 4;
        this.Sprite_Num = 6;
        this.Skill_Name = "���� ��Ÿ�� ����";
        this.Skill_Desc = "������ ��Ÿ���� 5�� ���ҽ�Ų��.";
        
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            if(Player_Stat.instance.dashCool >= 10)
                Player_Stat.instance.dashCool -= 5;  
        }      
    }
}
