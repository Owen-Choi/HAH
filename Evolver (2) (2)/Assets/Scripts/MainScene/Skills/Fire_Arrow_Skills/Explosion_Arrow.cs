using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Arrow : Skill_Manager
{
    public GameObject Explode;
    bool ChangeOnce;    bool ChangeTwice;   bool ChangeLast;
    public GameObject Fire_Arrow_ShotPoint;
    // Start is called before the first frame update
    void Start()
    {
        this.Skill_Num = 27;
        ChangeOnce = false;
        ChangeTwice = false;
        ChangeLast = false;
        this.Sprite_Num = 6;
        this.Skill_Name = "���߼� ȭ��";
        this.Skill_Desc = "ȭ���� ġ��Ÿ�� ����� �� �����ϸ� ū ���ظ� ������.";
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Selected_First && !ChangeOnce)
        {
            Fire_Arrow_ShotPoint.GetComponent<Fire_Arrow_ShotPoint>().is_Explode = true;
            //Player_Stat.instance.criticalPercent -= 10;       ������ ġ��Ÿ Ȯ���� 10% �ٿ����� �ϴ� �����غ���. ��ȭ���� �ʹ� ���ϴ�.
            ChangeOnce = true;
            this.Sprite_Num = 7;
            this.Skill_Desc = "ũ��Ƽ�� Ȯ��(ȭ���� ������ Ȯ��)�� 5% �����ϸ� ��� ������ ���� �������� 50% �����Ѵ�.";
        }

        if(this.Selected_Second && !ChangeTwice)
        {
            ChangeTwice = true;
            Player_Stat.instance.criticalPercent += 5;
            Player_Stat.instance.Explode_Multiple_Damage += 0.5f;
            this.Sprite_Num = 8;
            this.Skill_Desc = "��� ������ ���� �������� 50% �����Ѵ�.";
        }

        if(this.Selected_Last && !ChangeLast)
        {
            this.Selected = true;
            ChangeLast = true;
            Player_Stat.instance.Explode_Multiple_Damage += 0.5f;
            return;
        }
    }
}
