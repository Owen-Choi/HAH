using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCritical : Physical_Manager
{
    public GameObject Player;
    bool isDash;    bool One;
    float tempCritPercent;

    private void Awake()
    {
        this.Skill_Num = 37;
        //this.Sprite_Num = 
    }
    void Start()
    {
        isDash = Player.GetComponent<Player>().isDash;              //실시간으로 업데이트가 되나?
        One = false;
    }
    void Update()
    {
        if (this.Selected)
        {
            if (isDash && !One)
            {
                One = true;
                tempCritPercent = Player_Stat.instance.criticalPercent;
                Player_Stat.instance.criticalPercent += 30f;
                StartCoroutine("CriticalDuration");
            }
        }
    }

    IEnumerator CriticalDuration()
    {
        yield return new WaitForSeconds(5f);
        One = false;
        isDash = false;                                              //혹시 모르니 일단 false로 바꿔주자
    }
}
