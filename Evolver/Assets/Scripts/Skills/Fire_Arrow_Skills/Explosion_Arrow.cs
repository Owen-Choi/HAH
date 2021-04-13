using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Arrow : Skill_Manager
{
    bool ChangeOnce;    bool ChangeTwice;
    public GameObject Fire_Arrow_ShotPoint;
    // Start is called before the first frame update
    void Start()
    {
        this.Skill_Num = 27;
        ChangeOnce = false;
        ChangeTwice = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Selected_First && !ChangeOnce)
        {
            Fire_Arrow_ShotPoint.GetComponent<Fire_Arrow_ShotPoint>().is_Explode = true;
            Fire_Arrow_ShotPoint.GetComponent<Fire_Arrow_ShotPoint>().Explode_Percent = 10;
            ChangeOnce = true;
        }

        if(this.Selected_Second && !ChangeTwice)
        {
            Fire_Arrow_ShotPoint.GetComponent<Fire_Arrow_ShotPoint>().Explode_Percent = 20;
            ChangeTwice = true;
        }

        if(this.Selected_Last)
        {
            this.Selected = true;
            return;
        }
    }
}
