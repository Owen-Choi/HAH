using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchForceIncrease : Physical_Manager
{
    private void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.launchForce += 0.3f;
        }
    }
}
