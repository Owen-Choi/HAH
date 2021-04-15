using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBottle : Skill_Manager
{
    bool ChangeOnce;    bool ChangeTwice;
    public GameObject FlameBottleFor1;
    public GameObject FlameBottleFor2;
    public GameObject FlameBottleFor3;
    void Start()
    {
        this.Skill_Num = 29;
    }

   
    void Update()
    {
        if(this.Selected_First && !ChangeOnce)
        {
            ChangeOnce = true;
            FlameBottleFor1.GetComponent<FlameBottleFor1>().isActive = true;
        }

        if (this.Selected_Second && !ChangeTwice)
        {
            ChangeTwice = true;
            FlameBottleFor2.GetComponent<FlameBottleFor2>().isActive = true;
        }

        if (this.Selected_Last)
        {
            this.Selected = true;
            FlameBottleFor3.GetComponent<FlameBottleFor3>().isActive = true;
            return;
        }
    }
}
