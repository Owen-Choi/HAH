using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reinforce_Fast_Twich_Muscle : Physical_Manager
{
    
    void Start()
    {
        this.Skill_Name = "�ӱ� ��ȭ";
        this.Skill_Num = 17;
        this.Sprite_Num = 9;
        this.Skill_Desc = "���׹̳� ��뷮�� �����ϴ� ��� ���ݷ�, ��¡�ӵ�, ����ü �ӵ��� �����Ѵ�. (���׹̳� ��뷮 2 ����, ���ݷ� 7.5 ����, ��¡�ӵ� 0.65 ����, ����ü �ӵ� 3 ����)";
    }

   
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.Decrease_Stamina_When_Bow_Charge += 2;             //�׽�Ʈ �غ��� ��ġ �����ϱ�
            Player_Stat.instance.damage += 7.5f;
            Player_Stat.instance.ChargingSpeed += 0.65f;
            Player_Stat.instance.launchForce += 3;                                  //���������� ��ġ �����ϱ�
        }
    }
}
