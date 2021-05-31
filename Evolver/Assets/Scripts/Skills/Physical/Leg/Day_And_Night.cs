using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_And_Night :Physical_Manager
{
    float Original_MoveSpeed;   float Original_Dodge;
    bool isDay; bool isNight;
    void Start()
    {
        this.Skill_Num = 9;
        this.Skill_Name = "Day and Night";
        //this.Sprite_Num = 
        this.Skill_Desc = "Day : Movement speed increase,  Night : Dodge probability increase.  Day and Night will be swiitched every 8 seconds";
    }

   
    void Update()
    {
        if (this.Selected)
        {
            if (isDay)
                StartCoroutine("Day");
            else if (isNight)
                StartCoroutine("Night");
        }
    }

    IEnumerator Day()
    {
        yield return new WaitForSeconds(8f);
        Player_Stat.instance.moveSpeed = Original_MoveSpeed;
        isDay = false;
        isNight = true;
    }

    IEnumerator Night()
    {
        yield return new WaitForSeconds(8f);
        Player_Stat.instance.missPercent = Original_Dodge;
        isNight = false;
        isDay = true;
    }
}
