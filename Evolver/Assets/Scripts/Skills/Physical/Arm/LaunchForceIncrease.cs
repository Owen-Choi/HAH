using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchForceIncrease : Physical_Manager
{
    private void Awake()
    {
        this.Skill_Num = 12;
        this.Sprite_Num = 3;
        this.Skill_Name = "투사체 속도 증가";
        this.Skill_Desc = "화살이 날아가는 속도가 0.3 증가한다.";
    }
    private void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.launchForce += 0.3f;
        }
    }
}
