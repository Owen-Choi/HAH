using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedincrease : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 0;
        this.Sprite_Num = 1;
        this.Skill_Name = "�̵��ӵ� ����";
        this.Skill_Desc = "�̵��ӵ��� ������Ų��. (�̵� �ӵ� 0.25 ����)";
    }
    void Update()
    {
        if (Selected)
        {
            Player_Stat.instance.moveSpeed += 0.25f;
            this.Selected = false;
        }    
    }
}
