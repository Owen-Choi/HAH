using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShot : Skill_Manager
{

    public GameObject Middle_Left_ShotPoint;
    public GameObject Middle_Right_ShotPoint;
    public GameObject Full_Left_ShotPoint;
    public GameObject Full_Right_ShotPoint;

    bool DMG_Decrease_Once;
    bool DMG_Decrease_Twice;

    private void Start()
    {
        this.Skill_Num = 3;
        this.Selected_First = false;
        this.Selected_Second = false;
        this.Selected_Last = false;
        this.DMG_Decrease_Once = false;
        this.DMG_Decrease_Twice = false;
        this.Sprite_Num = 10;
        this.Skill_Name = "MultiShot";
        this.Skill_Desc = "Two additional arrow will be added";
    }

    /* public override void Activate()
    {
        if (!Selected_First)
        {
            this.Selected_First = true;
            return;
        }
        if (Selected_First && !Selected_Second)
        {
            this.Selected_Second = true;
            return;
        }
        else if (!Selected_Last)
        {
            this.Selected_Last = true;
            return;
        }
    } */

    public void Update()
    {                                           
        if (this.Selected_First)
        {
            //Middle_Left_ShotPoint.GetComponent<Middle_Left_ShotPoint>().enabled = true;   ���� �ڵ�
            Middle_Left_ShotPoint.gameObject.SetActive(true);
            Middle_Right_ShotPoint.gameObject.SetActive(true);
            if (!DMG_Decrease_Once)
            {
                this.Sprite_Num = 11;
                Player_Stat.instance.Charge_Damage_Plus -= 2;
                DMG_Decrease_Once = true;
            }
        }
        if(this.Selected_Second)                //else if ���ǹ����� ���� �տ��� �ɷ������� ������ else�� �ٿ����� �ȵȴ�.
        {
            Full_Left_ShotPoint.gameObject.SetActive(true);
            Full_Right_ShotPoint.gameObject.SetActive(true);
            if (!DMG_Decrease_Twice)
            {
                this.Sprite_Num = 12;
                Player_Stat.instance.Charge_Damage_Plus--;
                DMG_Decrease_Twice = true;
            }
        }

        if(this.Selected_Last)
        {
            this.Selected = true;
            Player_Stat.instance.Charge_Damage_Plus += 2;
            return;
            //ũ��Ƽ�� Ȯ�� ���ҿ� ������ �߰��� �־���ߵ� �� ����.
        }
    }
}
