using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soot : Skill_Manager
{
    public GameObject FireArrow;
    bool ChangeOnce;    bool ChangeTwice;   bool ChangeLast;
    void Start()
    {
        this.Skill_Num = 28;
        ChangeOnce = false;
        ChangeTwice = false;
        ChangeLast = false;
        this.Sprite_Num = 9;
        this.Skill_Name = "Soot";
        this.Skill_Desc = "When an enemy on fire contact with another enemy, the burn spreads ";
    }

   
    void Update()
    {
        if(this.Selected_First && !ChangeOnce)
        {
            ChangeOnce = true;
            FireArrow.GetComponent<Fire_Arrow>().isSoot = true;
        }

        if (this.Selected_Second && !ChangeTwice)
        {
            ChangeTwice = true;
            Player_Stat.instance.FireborneMax++;
            Player_Stat.instance.Burning_DMG += 0.0001f;
        }

        if(this.Selected_Last && !ChangeLast)
        {
            ChangeLast = true;
            this.Selected = true;
            Player_Stat.instance.FireborneMax++;
            Player_Stat.instance.Burning_DMG += 0.0001f;
            return;
        }
    }
}
