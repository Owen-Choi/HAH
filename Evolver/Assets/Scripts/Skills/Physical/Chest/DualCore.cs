using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualCore : Physical_Manager
{
    int PlayerLevel;
    private void Awake()
    {
        PlayerLevel = Player_Stat.instance.Physical_Level;
    }
    private void Update()
    {
        if (this.Selected)
        {
            if (PlayerLevel < Player_Stat.instance.Physical_Level)
            {
                PlayerLevel = Player_Stat.instance.Physical_Level;
                Player_Stat.instance.DefaultHealthMax += 5f;
            }
        }        
    }
}
