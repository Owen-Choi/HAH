using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soot : Skill_Manager
{
    public GameObject FireArrow;
    bool ChangeOnce;    bool ChangeTwice;   bool ChangeLast;
    void Start()
    {
        this.Skill_Num = 28;
        ChangeOnce = false;
        ChangeTwice = false;
        ChangeLast = false;
        this.Sprite_Num = 9;
        this.Skill_Name = "������";
        this.Skill_Desc = "ȭ���� ���� ��ä�� �ڽŰ� ������ �� 1���� ȭ���� ���̽�Ų��.";
    }

   
    void Update()
    {
        if(this.Selected_First && !ChangeOnce)
        {
            ChangeOnce = true;
            FireArrow.GetComponent<Fire_Arrow>().isSoot = true;
            this.Skill_Desc = "ȭ���� ���� ��ä�� �ڽŰ� ������ �� 2���� ȭ���� ���̽�Ű��, ȭ���� �ִ� ���ط��� �����Ѵ�.";
            this.Sprite_Num = 16;
        }

        if (this.Selected_Second && !ChangeTwice)
        {
            ChangeTwice = true;
            Player_Stat.instance.FireborneMax++;
            Player_Stat.instance.Burning_DMG += 5f;
            this.Skill_Desc = "ȭ���� ���� ��ä�� �ڽŰ� ������ �� 3���� ȭ���� ���̽�Ű��, ȭ���� �ִ� ���ط��� �����Ѵ�.";
            this.Sprite_Num = 17;
        }

        if(this.Selected_Last && !ChangeLast)
        {
            ChangeLast = true;
            this.Selected = true;
            Player_Stat.instance.FireborneMax++;
            Player_Stat.instance.Burning_DMG += 5f;
            return;
        }
    }
}
