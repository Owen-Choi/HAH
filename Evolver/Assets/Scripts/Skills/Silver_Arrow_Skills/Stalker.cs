using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : Skill_Manager
{
    public GameObject SilverArrowShotPoint; bool isOnce;
    void Start()
    {
        this.Skill_Num = 22;
        this.Skill_Name = "����Ŀ";
        //this.Sprite_Num =
        this.Skill_Desc = "�÷��̾ �߰����� ���� ������ 2���� ���ظ� �ش�.";
    }

    
    void Update()
    {
        if (this.Selected && !isOnce)
        {
            isOnce = true;
            SilverArrowShotPoint.GetComponent<Silver_Arrow_ShotPoint>().isStalker = true;
            //this.enabled = false;               ������Ʈ �Լ��� �������� �𸣰ڴ�.   # ��ũ��Ʈ ��ü�� ������. �̰� �ϴ� �����غ���.
        }
    }
}
