using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyro : Skill_Manager
{
    
    // Start is called before the first frame update
    void Start()
    {
        this.Skill_Num = 26;
        this.Sprite_Num = 5;
        this.Skill_Name = "��ȭ��";
        this.Skill_Desc = "���� ȭ���� ���� ��� ���� Ȯ���� ����Ѵ�.";
    }

    // Update is called once per frame
    void Update()
    {
        if(this.Selected_First)
        {
            this.Selected = true;
            Player_Stat.instance.isPyro = true;           //������ ������ �ִ�. �����ֽ��ϱ�
            return;
        }
    }
}
