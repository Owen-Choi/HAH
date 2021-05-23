using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Master : Skill_Manager
{
    public GameObject Player;
    private void Start()
    {
        this.Skill_Num = 17;
        this.Sprite_Num = 15;
        this.Skill_Name = "Dash Master";
        this.Skill_Desc = "You can dash without stamina and dash's cool time will be reduced as 10 secs";
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
