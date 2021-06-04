using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penetrate : Skill_Manager
{
    bool Once;
    bool Twice;
    public GameObject Silver_Arrow_ShotPoint;
    void Start()
    {
        this.Skill_Num = 18;
        this.Sprite_Num = 4;
        this.Once = false;
        this.Twice = false;
        this.Skill_Name = "관통";
        this.Skill_Desc = "차징 시 스테미나 소모량이 감소한다.";
    }


    void Update()
    {
        if (this.Selected_First)
        { 
            if(!this.Once)
            {
                this.Once = true;
                this.Sprite_Num = 5;
                Player_Stat.instance.Decrease_Stamina_When_Bow_Charge = 4f;                    //changing this values may cause some errors
                this.Skill_Desc = "차징속도가 증가한다.";
            }
            
        }
        if (this.Selected_Second)
        {
            if (!this.Twice)
            {
                this.Twice = true;
                this.Sprite_Num = 6;
                Player_Stat.instance.ChargingSpeed += 0.4f;                                     //수치 조정해야할 가능성 있음.  지금 보니 딱 적당한 듯
                this.Skill_Desc = "치명타가 발생할 때마다 스테미나를 회복한다.";
            }
           
        }
        if (this.Selected_Last)
        {
            Player_Stat.instance.is_Penetrate3 = true;
            this.Selected = true;
            return;
        }
    }
}
