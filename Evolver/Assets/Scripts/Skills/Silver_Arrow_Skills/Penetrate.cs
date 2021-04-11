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
            Player_Stat.instance.Decrease_Stamina_When_Bow_Charge = 0.0015f;                    //changing this values may cause some errors
        if (this.Selected_Second)
            Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().Penetrate = true;
    }
}
