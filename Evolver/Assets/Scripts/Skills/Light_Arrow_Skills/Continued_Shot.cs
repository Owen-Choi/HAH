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
            Player_Stat.instance.is_Continued_Shot = true;

        if (this.Selected_Second)
            Player_Stat.instance.is_Continued_Shot2 = true;

        if(this.Selected_Last)
        {
            ;
            this.GetComponent<Continued_Shot>().enabled = false;
        }
    }
}
