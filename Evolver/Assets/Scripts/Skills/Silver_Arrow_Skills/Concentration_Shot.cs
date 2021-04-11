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
    }

    private void Update()
    {
        if (this.Selected_First)
        {
            // 시작 값 - 끝나는 값 만큼 데미지 +
            Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().concen = true;
            this.GetComponent<Concentration_Shot>().enabled = false;
        }
    }
}
