using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioActiveDMG : Physical_Manager
{
    float radioActive;  float Damage;
    void Awake()
    {
        radioActive = Player_Stat.instance.RadioActive;
    }
    void Update()
    {
        if (this.Selected)
        {
            Damage = Player_Stat.instance.damage + radioActive * 0.5f;
            Player_Stat.instance.damage = Damage;
        }
    }
}
