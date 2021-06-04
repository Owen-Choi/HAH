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
        this.Skill_Name = "가시";
        this.Skill_Desc = "적과 충돌할 시 4%의 확률로 적을 즉사시킨다.";
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
