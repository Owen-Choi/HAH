using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Critical_Damage_Increase : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 35;
        this.Sprite_Num = 7;
        this.Skill_Name = "ġ��Ÿ ���ط� ����";
        this.Skill_Desc = "ġ��Ÿ ���ط��� �����Ѵ�. (ġ��Ÿ ���ط� 20% ���� )";
    }
    private void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.criticalDamage += 20f;     //��ġ ���� ���ɼ� ����
        }
    }
}
