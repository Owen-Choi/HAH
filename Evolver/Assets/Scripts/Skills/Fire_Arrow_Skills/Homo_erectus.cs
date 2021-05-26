using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homo_erectus : Skill_Manager
{
    public GameObject Kitchen;
    bool ForOnce;
    void Start()
    {
        this.Skill_Num = 30;
        this.Sprite_Num = 23;
        this.Skill_Name = "Homo erectus";
        this.Skill_Desc = "More radioacive will be decreased by food";
        ForOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Selected && !ForOnce)
        {
            ForOnce = true;
            Kitchen.GetComponent<Kitchen>().RadioActiveDecrease += 10;
        }
    }
}
