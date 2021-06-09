using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Master : Skill_Manager
{
    public GameObject Player;
    private void Start()
    {
        this.Skill_Num = 17;
        this.Sprite_Num = 3;
        this.Skill_Name = "질주의 달인";
        this.Skill_Desc = "스테미나 소모 없이 질주할 수 있고 질주의 재사용 대기시간이 10초 감소한다.";
    }

    private void Update()
    {
        if(this.Selected_First)
        {
            this.Selected = true;
            Player.GetComponent<Player>().DashMaster = true;
            return;
        }
    }


}
