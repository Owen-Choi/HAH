using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchForceIncrease : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 12;
        this.Sprite_Num = 3;
        this.Skill_Name = "����ü �ӵ� ����";
        this.Skill_Desc = "ȭ���� ���ư��� �ӵ��� 0.3 �����Ѵ�.";
    }
    private void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.launchForce += 0.3f;
        }
    }
}
