using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindStep : Skill_Manager
{
    public bool TimeDone = false;
    bool ForOne = false;
    public float time = 0f;
    public GameObject ShotPoint;
    GameObject SP;
    bool isShoot;
    
    void Start()
    {
        this.Skill_Num = 6;
        this.Sprite_Num = 2;
        this.Skill_Name = "Wind Step";
        this.Skill_Desc = "Your dodge percent will be increased and your movement speed will be increased temporarily when you attack enemy";
    }


    void Update()
    {
        if (this.Selected_First)
        {
            if (!ForOne)
            {
                Player_Stat.instance.missPercent += 5;
                ForOne = true;
            }
            this.Selected = true;
            if (ShotPoint.GetComponent<ShotPoint>().isShoot && !TimeDone)           //비효율적인 코드지만 개선안이 생각나지 않는다....
                ws();
        }
    }

    void ws()
    {
        TimeDone = true;
        Player_Stat.instance.moveSpeed += 2;
        StartCoroutine("ThreeSecDelay");

    }

    IEnumerator ThreeSecDelay()
    {
        yield return new WaitForSeconds(3f);
        Player_Stat.instance.moveSpeed -= 2;
        TimeDone = false;
    }

}