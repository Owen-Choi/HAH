using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_And_Night :Physical_Manager
{
    float Original_MoveSpeed;   float Original_Dodge;   float DefaultMoveSpeed; float DefaultDodge;
    public GameObject Player;
    GameObject PlayerCache;
    bool isDay; bool isNight;   bool DayOnce;   bool NightOnce;
    void Start()
    {
        this.Skill_Num = 9;
        this.Skill_Name = "Day and Night";
        //this.Sprite_Num = 
        this.Skill_Desc = "Day : Movement speed increase,  Night : Dodge probability increase.  Day and Night will be swiitched every 8 seconds";
        PlayerCache = Player;
        isDay = true;
        Original_MoveSpeed = Player_Stat.instance.moveSpeed;
        Original_Dodge = Player_Stat.instance.missPercent;
    }

   
    void Update()
    {
        if (this.Selected)
        {
            if (PlayerCache.layer == LayerMask.NameToLayer("PlayerInShelter"))
            {
                Original_MoveSpeed = Player_Stat.instance.moveSpeed;
                Original_Dodge = Player_Stat.instance.missPercent;
            }
            else
            {
                if (isDay && !DayOnce)
                {
                    DayOnce = true;
                    Player_Stat.instance.moveSpeed += 1f;
                    StartCoroutine("Day");
                }
                else if (isNight && !NightOnce)
                {
                    NightOnce = true;
                    Player_Stat.instance.missPercent += 5f;
                    StartCoroutine("Night");
                }
            }
        }
       
    }

    IEnumerator Day()
    {
        yield return new WaitForSeconds(8f);
        // # 다른 버프로 이동속도가 증가했을 경우 버프가 초기화되지 않게 하기 위한 조건문
        Player_Stat.instance.moveSpeed = Original_MoveSpeed;
        isDay = false;
        isNight = true;
        DayOnce = false;
    }
    
    IEnumerator Night()
    {
        yield return new WaitForSeconds(8f);
        Player_Stat.instance.missPercent = Original_Dodge;
        isNight = false;
        isDay = true;
        NightOnce = false;
    }
}
