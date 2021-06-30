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
        this.Skill_Name = "그을림";
        this.Skill_Desc = "화상을 입은 개채가 자신과 접촉한 적 1명에게 화상을 전이시킨다.";
    }

   
    void Update()
    {
        if(this.Selected_First && !ChangeOnce)
        {
            ChangeOnce = true;
            FireArrow.GetComponent<Fire_Arrow>().isSoot = true;
            this.Skill_Desc = "화상을 입은 개채가 자신과 접촉한 적 2명에게 화상을 전이시키며, 화상이 주는 피해량이 증가한다.";
            this.Sprite_Num = 16;
        }

        if (this.Selected_Second && !ChangeTwice)
        {
            ChangeTwice = true;
            Player_Stat.instance.FireborneMax++;
            Player_Stat.instance.Burning_DMG += 5f;
            this.Skill_Desc = "화상을 입은 개채가 자신과 접촉한 적 3명에게 화상을 전이시키며, 화상이 주는 피해량이 증가한다.";
            this.Sprite_Num = 17;
        }

        if(this.Selected_Last && !ChangeLast)
        {
            ChangeLast = true;
            this.Selected = true;
            Player_Stat.instance.FireborneMax++;
            Player_Stat.instance.Burning_DMG += 5f;
            return;
        }
    }
}
