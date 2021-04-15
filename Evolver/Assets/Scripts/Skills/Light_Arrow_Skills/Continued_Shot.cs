using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continued_Shot : Skill_Manager
{

    private void Start()
    {
        this.Skill_Num = 4;
        //this.Selected_First = false;
        //this.Selected_Second = false;
        //this.Selected_Last = false;
    }

   

    void Update()
    {
        if (this.Selected_First)
            //공격력 감소 구현해야함
            Player_Stat.instance.is_Continued_Shot = true;

        if (this.Selected_Second)
            //공격력 감소 구현해야함
            Player_Stat.instance.is_Continued_Shot2 = true;

        if(this.Selected_Last)
        {
            this.Selected = true;
            //투사체 속도 증가, 딜 증가 구현해야함
            this.GetComponent<Continued_Shot>().enabled = false;
            return;
        }
    }
}
