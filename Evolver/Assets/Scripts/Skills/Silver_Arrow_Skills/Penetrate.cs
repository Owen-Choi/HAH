using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penetrate : Skill_Manager
{
    bool Once;
    bool Twice;
    public GameObject Silver_Arrow_ShotPoint;
    void Start()
    {
        this.Skill_Num = 18;
        this.Sprite_Num = 4;
        this.Once = false;
        this.Twice = false;
        this.Skill_Name = "Penetration";
        this.Skill_Desc = "+ : decreases stamina need when charging" + "" +
            "++ : increases Charging speed" + "" +
            "+++ : Small amount of stamina recovered from critical shot";
    }


    void Update()
    {
        if (this.Selected_First)
        { 
            if(!this.Once)
            {
                this.Once = true;
                this.Sprite_Num = 5;
            }
            Player_Stat.instance.Decrease_Stamina_When_Bow_Charge = 4f;                    //changing this values may cause some errors
        }
        if (this.Selected_Second)
        {
            if (!this.Twice)
            {
                this.Twice = true;
                this.Sprite_Num = 6;
            }
            Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().Penetrate = true;
        }
        if (this.Selected_Last)
        {
            Player_Stat.instance.is_Penetrate3 = true;
            this.Selected = true;
            return;
        }
    }
}
