using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : Skill_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    bool isOnce;
    void Start()
    {
        this.Skill_Num = 8;
        //this.Sprite_Num =
        this.Skill_Name = "Thorn";
        this.Skill_Desc = "Enemy will be killed immediately with low probabiliy if you being damaged by them";
        PlayerCache = Player;
    }

    void Update()
    {
        if (this.Selected && !isOnce)
        {
            isOnce = true;
            PlayerCache.GetComponent<Player>().isThorn = true;
        }    
    }
}
