using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash_Arrow : Skill_Manager
{
    public GameObject SilverArrowShotPoint;
    GameObject SASP;
    bool isOnce;
    void Start()
    {
        this.Skill_Num = 20;
        //this.Sprite_Num = 
        this.Skill_Name = "Flash Arrow";
        SASP = SilverArrowShotPoint;
        isOnce = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Selected && isOnce)
        {
            isOnce = false;
            SASP.GetComponent<Silver_Arrow_ShotPoint>().isFlash = true;
        }
    }
}
