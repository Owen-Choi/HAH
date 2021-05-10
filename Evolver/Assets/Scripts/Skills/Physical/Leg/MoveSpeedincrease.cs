using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedincrease : Physical_Manager
{
    void Update()
    {
        if (Selected)
        {
            Player_Stat.instance.moveSpeed += 0.5f;
            this.Selected = false;
        }    
    }
}
