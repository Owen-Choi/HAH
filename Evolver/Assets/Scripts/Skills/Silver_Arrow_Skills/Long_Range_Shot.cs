using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Long_Range_Shot : Skill_Manager
{
    public GameObject Silver_Arrow_ShotPoint;
    private void Start()
    {
        this.Skill_Num = 16;
    }

    private void Update()
    {
        if(this.Selected_First)
        {
            Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().Long_range = true;
            this.GetComponent<Long_Range_Shot>().enabled = false;
        }
    }
}
