using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning_Cloak : Skill_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    public bool isOnce;
    void Start()
    {
        this.Skill_Num = 30;
        this.Skill_Name = "Burning Cloak";
        //this.Sprite_Num =
        this.Skill_Desc = "Make enemy burn if you hit by them";
        PlayerCache = Player;
    }

   
    void Update()
    {
        if (this.Selected && !isOnce)
        {
            isOnce = true;
            PlayerCache.GetComponent<Player>().isBurningCloak = true;
        }
    }
}
