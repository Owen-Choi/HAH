using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : Skill_Manager
{
    bool ChangeOnce;    bool ChangeTwice;
    // Start is called before the first frame update
    void Start()
    {
        this.Skill_Num = 25;
        ChangeOnce = false;
        ChangeTwice = false;
        this.Skill_Num = 25;        //기름 스킬의 스프라이트가 아니다. 일단은 임시로 사용 중이니 다시 찍어달라고 하자.
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Selected_First && !ChangeOnce)
        {
            Player_Stat.instance.Burn_Percent = 40f;
            ChangeOnce = true;
        }
        if (this.Selected_Second && !ChangeTwice)
        {
            Player_Stat.instance.Burn_Percent = 60f;
            ChangeTwice = true;
        }
        if(this.Selected_Last)
        {
            this.Selected = true;
            Player_Stat.instance.Burn_Percent = 100f;
            return;
        }
        
    }
}
