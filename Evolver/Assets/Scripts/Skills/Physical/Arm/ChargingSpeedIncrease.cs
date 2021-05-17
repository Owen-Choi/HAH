using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingSpeedIncrease : Physical_Manager
{
   
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            if (Player_Stat.instance.ChargingSpeed < 8f)
                Player_Stat.instance.ChargingSpeed += 1f;
        }
    }
}
