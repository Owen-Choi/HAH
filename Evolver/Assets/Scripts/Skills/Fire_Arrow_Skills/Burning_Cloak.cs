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
        this.Skill_Name = "태양의 망토";
        this.Skill_Desc = "적과 충돌할 시 적을 화상상태로 만든다.";
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
