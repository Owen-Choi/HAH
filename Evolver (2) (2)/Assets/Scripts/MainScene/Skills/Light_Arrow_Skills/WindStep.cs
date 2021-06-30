using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindStep : Skill_Manager
{
    public bool TimeDone = false;
    bool ForOne = false;
    public float time = 0f;
    public GameObject ShotPoint;
    public GameObject BuffCarrier;
    GameObject SP;
    GameObject BCcache;
    bool isShoot;
    
    void Start()
    {
        this.Skill_Num = 6;
        this.Sprite_Num = 2;
        this.Skill_Name = "바람걸음";
        this.Skill_Desc = "회피율이 영구적으로 증가하고 적을 공격할 때 마다 일시적으로 이동속도가 증가한다.";
        BCcache = BuffCarrier;
        SP = ShotPoint;
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
            if (SP.GetComponent<ShotPoint>().isShoot && !TimeDone)           //비효율적인 코드지만 개선안이 생각나지 않는다....
                ws();
        }
    }

    void ws()
    {
        TimeDone = true;
        //Player_Stat.instance.moveSpeed += 2;
        BCcache.GetComponent<Buff_Carrier>().buff_MS += 2;
        StartCoroutine("ThreeSecDelay");

    }

    IEnumerator ThreeSecDelay()
    {
        yield return new WaitForSeconds(3f);
        //Player_Stat.instance.moveSpeed -= 2;
        BCcache.GetComponent<Buff_Carrier>().buff_MS -= 2;
        TimeDone = false;
    }

}