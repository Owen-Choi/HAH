using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : Skill_Manager
{
    public GameObject SilverArrowShotPoint;
    void Start()
    {
        this.Skill_Num = 22;
        this.Skill_Name = "Stalker";
        //this.Sprite_Num =
        this.Skill_Desc = "";
    }

    
    void Update()
    {
        if (this.Selected)
        {
            SilverArrowShotPoint.GetComponent<Silver_Arrow_ShotPoint>().isStalker = true;
            //this.enabled = false;               ������Ʈ �Լ��� �������� �𸣰ڴ�.   # ��ũ��Ʈ ��ü�� ������. �̰� �ϴ� �����غ���.
        }
    }
}
