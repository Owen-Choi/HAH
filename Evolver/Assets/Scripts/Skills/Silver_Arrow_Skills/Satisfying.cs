using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satisfying : Skill_Manager
{
    public GameObject SilverArrowShotPoint;
    bool isOnce;
    void Start()
    {
        this.Skill_Num = 23;
        this.Skill_Name = "Satisfying";
        //this.Sprite_Num =
        this.Skill_Desc = "";
        isOnce = false;
    }

    
    void Update()
    {
        if (!isOnce && this.Selected)
        {
            isOnce = true;
            SilverArrowShotPoint.GetComponent<Silver_Arrow_ShotPoint>().isSatisfying = true;
        }
    }
}
