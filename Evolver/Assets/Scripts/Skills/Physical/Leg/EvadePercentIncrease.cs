using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadePercentIncrease : Physical_Manager
{ 
    void Update()
    {
        if (Selected)
        {
            Player_Stat.instance.missPercent += 5;
            this.Selected = false;
        }
    }
}
