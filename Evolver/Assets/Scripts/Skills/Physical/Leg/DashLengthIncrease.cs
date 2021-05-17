using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashLengthIncrease : Physical_Manager
{
    float DashTime;
    private void Awake()
    {
        this.DashTime = Player_Stat.instance.DashTime;
    }

    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            if (this.DashTime < 1.5f)
                Player_Stat.instance.DashTime += 0.15f;
            this.DashTime = Player_Stat.instance.DashTime;
        }
    }
}
