using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Physical_Manager
{
    public GameObject BackPack;
    int original_FoodDrop;
    private void Awake()
    {
        this.Skill_Num = 40;
        this.Sprite_Num = 2;
        this.Skill_Name = "좀도둑";
        this.Skill_Desc = "식량의 드롭율이 6% 증가한다.";
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            original_FoodDrop = BackPack.GetComponent<BackPack>().GetDropPercent("Food");
            original_FoodDrop += 6;
            BackPack.GetComponent<BackPack>().setDropPercent("Food", original_FoodDrop);
        }       
    }
}
