using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Max_Stamina_Increase : Physical_Manager
{
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.DefaultStaminaMax += 5;
        }       
    }
}
