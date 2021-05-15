using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Critical_Damage_Increase : Physical_Manager
{
    private void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.criticalDamage += 30f;
        }
    }
}
