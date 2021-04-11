using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Master : Skill_Manager
{
    public GameObject Player;
    private void Start()
    {
        this.Skill_Num = 17;
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
