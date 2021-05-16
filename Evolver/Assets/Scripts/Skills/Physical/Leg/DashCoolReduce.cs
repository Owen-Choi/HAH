using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCoolReduce : Physical_Manager
{
  
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;

        }      
    }
}
