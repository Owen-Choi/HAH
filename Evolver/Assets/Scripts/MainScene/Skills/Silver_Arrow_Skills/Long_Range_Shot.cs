using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Long_Range_Shot : Skill_Manager
{
    public GameObject Silver_Arrow_ShotPoint;
    private void Start()
    {
        this.Skill_Num = 16;
        this.Sprite_Num = 1;
        this.Skill_Name = "장거리 사격";
        this.Skill_Desc = "일정 거리 밖의 적을 사격할 시 데미지가 증가한다.";
    }

    private void Update()
    {
        if(this.Selected_First)
        {
            this.Selected = true;
            Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().Long_range = true;
            return;
        }
    }
}
