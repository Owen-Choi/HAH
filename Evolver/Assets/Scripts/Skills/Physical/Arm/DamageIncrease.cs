using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : Physical_Manager
{
    void Update()
    {
        if(Selected)
        {
            Player_Stat.instance.damage += 5;
            this.Selected = false;
        }
    }
}
