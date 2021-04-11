using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penetrate : Skill_Manager
{
    public GameObject Silver_Arrow_ShotPoint;
    void Start()
    {
        this.Skill_Num = 18;
    }

    
    void Update()
    {
        if(this.Selected_First)
            Player_Stat.instance.Decrease_Stamina_When_Bow_Charge = 4f;                    //changing this values may cause some errors
        if (this.Selected_Second)
            Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().Penetrate = true;
        if (this.Selected_Last)
        {
            Player_Stat.instance.is_Penetrate3 = true;
            this.Selected = true;
            return;
        }
    }
}
