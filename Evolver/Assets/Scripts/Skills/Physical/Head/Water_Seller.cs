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
        this.Sprite_Num = 33;
        Original_WaterDrop = BackPack.GetComponent<BackPack>().GetDropPercent("Water");
        this.Skill_Name = "Water seller";
        this.Skill_Desc = "Water drop probability will be increased";
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Original_WaterDrop += 10;
            BackPack.GetComponent<BackPack>().setDropPercent("Water", Original_WaterDrop);
        }
    }
}
