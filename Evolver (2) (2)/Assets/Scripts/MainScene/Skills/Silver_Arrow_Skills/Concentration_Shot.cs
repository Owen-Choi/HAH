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
        this.Skill_Name = "집중";
        this.Skill_Desc = "시위를 당기며 소모된 스테미나의 수치만큼 데미지가 증가한다.";
    }

    private void Update()
    {
        if (this.Selected_First)
        {
            // 시작 값 - 끝나는 값 만큼 데미지 +
            this.Selected = true;
            Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().concen = true;
            return;
        }
    }
}
