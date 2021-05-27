using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : Skill_Manager
{
    bool ChangeOnce;    bool ChangeTwice;
    // Start is called before the first frame update
    void Start()
    {
        this.Skill_Num = 25;
        ChangeOnce = false;
        ChangeTwice = false;
        this.Sprite_Num = 13;
        this.Skill_Name = "Oil";
        this.Skill_Desc = "+ : There is an increased chance of burning the enemy " +
            "++ : There is an increased chance of burning the enemy " +
            "+++ : Every attack causes burning ";
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Selected_First && !ChangeOnce)
        {
            Player_Stat.instance.Burn_Percent = 40f;
            ChangeOnce = true;
            this.Sprite_Num = 14;
        }
        if (this.Selected_Second && !ChangeTwice)
        {
            Player_Stat.instance.Burn_Percent = 60f;
            ChangeTwice = true;
            this.Sprite_Num = 15;
        }
        if(this.Selected_Last)
        {
            this.Selected = true;
            Player_Stat.instance.Burn_Percent = 100f;
            return;
        }
        
    }
}
