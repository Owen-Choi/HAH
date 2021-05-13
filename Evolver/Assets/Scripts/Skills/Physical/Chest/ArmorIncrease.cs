using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorIncrease : Physical_Manager
{
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.armor += 2.5f;
        }
    }
}
