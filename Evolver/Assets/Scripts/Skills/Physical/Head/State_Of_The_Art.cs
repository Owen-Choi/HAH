using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Of_The_Art : Physical_Manager
{
    bool Available;
    void Start()
    {
        this.Skill_Num = 44;
        //this.Sprite_Num =
        this.Skill_Name = "State of the Art";
        this.Skill_Desc = "";
        Available = true;
    }

    
    void Update()
    {
        // # Player_Stat의 AbsolCrit 변수를 활용해보자
        if (this.Selected)
        {
            if (Input.GetKeyDown(KeyCode.L) && Player_Stat.instance.stamina >= 50 && Available){
                Available = false;
                Player_Stat.instance.stamina -= 50;
                Player_Stat.instance.AbsolCrit = true;
                StartCoroutine("Duration");
            }

            if (!Available)
                StartCoroutine("CoolTime");
        }
    }
    IEnumerator Duration()
    {
        yield return new WaitForSeconds(5f);
        Player_Stat.instance.AbsolCrit = false;
    }
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(60f);
        Available = true;
    }
}
