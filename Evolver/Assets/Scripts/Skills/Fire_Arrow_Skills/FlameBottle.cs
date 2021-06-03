using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBottle : Skill_Manager
{
    bool ChangeOnce;    bool ChangeTwice;
    public GameObject FlameBottleFor1;
    public GameObject FlameBottleFor2;
    public GameObject FlameBottleFor3;
    GameObject FlameBottleFor1Cache;
    GameObject FlameBottleFor2Cache;
    GameObject FlameBottleFor3Cache;

    public GameObject FlameBottle1UI;
    public GameObject FlameBottle2UI;
    public GameObject FlameBottle3UI;
    void Start()
    {
        this.Skill_Num = 29;
        this.Sprite_Num = 10;
        this.Skill_Name = "Flame bottle";
        this.Skill_Desc = "you can use explosive flame bottle";
        FlameBottleFor1Cache = FlameBottleFor1;
        FlameBottleFor2Cache = FlameBottleFor2;
        FlameBottleFor3Cache = FlameBottleFor3;
    }

   
    void Update()
    {
        if(this.Selected_First && !ChangeOnce)
        {
            ChangeOnce = true;
            FlameBottleFor1Cache.GetComponent<FlameBottleFor1>().isActive = true;
            this.Sprite_Num = 11;
            FlameBottle1UI.gameObject.SetActive(true);
        }

        if (this.Selected_Second && !ChangeTwice)
        {
            ChangeTwice = true;
            FlameBottleFor2Cache.GetComponent<FlameBottleFor2>().isActive = true;
            this.Sprite_Num = 12;
            FlameBottle2UI.gameObject.SetActive(true);
        }

        if (this.Selected_Last)
        {
            this.Selected = true;
            FlameBottleFor3Cache.GetComponent<FlameBottleFor3>().isActive = true;
            FlameBottle3UI.gameObject.SetActive(true);
            return;
        }
    }
}
