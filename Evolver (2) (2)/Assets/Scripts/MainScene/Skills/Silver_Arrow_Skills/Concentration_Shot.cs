using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concentration_Shot : Skill_Manager
{
    float First;    float Second;   float Gap;
    public GameObject Silver_Arrow_ShotPoint;
    private void Start()
    {
        this.Skill_Num = 15;
        this.Sprite_Num = 2;
        this.Skill_Name = "����";
        this.Skill_Desc = "������ ���� �Ҹ�� ���׹̳��� ��ġ��ŭ �������� �����Ѵ�.";
    }

    private void Update()
    {
        if (this.Selected_First)
        {
            // ���� �� - ������ �� ��ŭ ������ +
            this.Selected = true;
            Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().concen = true;
            return;
        }
    }
}
