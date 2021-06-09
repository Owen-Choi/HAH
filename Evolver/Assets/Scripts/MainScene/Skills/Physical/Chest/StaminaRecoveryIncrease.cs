using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaRecoveryIncrease :  Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 23;
        this.Sprite_Num = 7;
        this.Skill_Name = "���׹̳� ȸ���ӵ� ����";
        this.Skill_Desc = "���׹̳��� ȸ�� �ӵ��� 1 �����Ѵ�.";
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.Stamina_recovery_speed += 1f;          //��ġ ���� ���ɼ� ����.
        }
    }
}
