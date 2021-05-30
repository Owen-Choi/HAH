using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protect_Position : Physical_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    bool available;
    void Start()
    {
        this.Skill_Num = 31;
        //this.Sprite_Num =
        this.Skill_Name = "Protection";
        this.Skill_Desc = "You can protect enemy's attack once with 40 stamina, just Press P";
        PlayerCache = Player;
        available = true;

    }

    
    void Update()
    {
        if (this.Selected)
        {
            if (Input.GetKeyDown(KeyCode.P) && Player_Stat.instance.stamina >= 40 && available)
            {
                available = false;
                Player_Stat.instance.stamina -= 40;
                PlayerCache.layer = LayerMask.NameToLayer("Player_Defense");
            }
        }
    }
    // # 재사용 대기시간 40초
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(40f);
        available = true;

    }
}
