using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindStep : Skill_Manager
{
    public bool TimeDone = false;
    bool ForOne = false;
    public float time = 0f;
    public GameObject ShotPoint;
    void Start()
    {
        this.Skill_Num = 6;
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
            if (ShotPoint.GetComponent<ShotPoint>().isShoot && !TimeDone)
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