using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Long_Range_Shot : Skill_Manager
{
    public GameObject Silver_Arrow_ShotPoint;
    private void Start()
    {
        this.Skill_Num = 16;
        this.Sprite_Num = 13;
        this.Skill_Name = "Long-range shot";
        this.Skill_Desc = "Increases damage when shooting enemies outside a range";
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
