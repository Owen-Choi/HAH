using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continued_Shot : Skill_Manager
{
    bool DMG_Decrease_Once;
    bool DMG_Decrease_Twice;
    private void Start()
    {
        this.DMG_Decrease_Once = false;
        this.DMG_Decrease_Twice = false;
        this.Skill_Num = 4;
        //this.Selected_First = false;
        //this.Selected_Second = false;
        //this.Selected_Last = false;
        this.Sprite_Num = 7;
    }

   

    void Update()
    {
        if (this.Selected_First)
            if (!DMG_Decrease_Once)
            {
                DMG_Decrease_Once = true;
                this.Sprite_Num = 8;
                //공격력 감소 구현해야함
            }
            Player_Stat.instance.is_Continued_Shot = true;

        if (this.Selected_Second)
            if (!DMG_Decrease_Twice)
            {
                this.Sprite_Num = 9;
                DMG_Decrease_Twice = true;
                //공격력 감소 구현해야함
            }
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
