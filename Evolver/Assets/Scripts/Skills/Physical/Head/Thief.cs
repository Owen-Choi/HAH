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
        this.Sprite_Num = 32;
        original_FoodDrop = BackPack.GetComponent<BackPack>().GetDropPercent("Food");
    }
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            original_FoodDrop += 10;
            BackPack.GetComponent<BackPack>().setDropPercent("Food", original_FoodDrop);
        }       
    }
}
