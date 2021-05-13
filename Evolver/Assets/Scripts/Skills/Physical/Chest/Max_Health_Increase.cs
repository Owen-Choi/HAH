using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Max_Health_Increase : Physical_Manager
{
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.DefaultHealthMax += 20;
        }    
    }
}
