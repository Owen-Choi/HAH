using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Seller : Physical_Manager
{

    public GameObject BackPack;
    int Original_WaterDrop;

    private void Awake()
    {
        this.Skill_Num = 41;
        this.Sprite_Num = 3;
        this.Skill_Name = "물장수";
        this.Skill_Desc = "물의 드롭율이 6% 증가한다.";
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Original_WaterDrop = BackPack.GetComponent<BackPack>().GetDropPercent("Water");
            Original_WaterDrop += 6;
            BackPack.GetComponent<BackPack>().setDropPercent("Water", Original_WaterDrop);
            
        }
    }
}
