using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refill_Stamina : Physical_Manager
{
    // # 연타하면 스테미나가 가득 차는 현상을 방지하기 위해 스테미나가 50퍼센트 이상이 넘어야 다시 기회가 생기는 시스템으로 만들었다.
    bool isAble;

    private void Awake()
    {
        isAble = true;
        this.Skill_Num = 29;
        //this.Sprite_Num = 8;    
        this.Skill_Name = "Stamina re-fill";
        this.Skill_Desc = "if your stamina is zero, your stamina immediately jump to max value by 10 percent probability";
    }
    void Update()
    {
        if (this.Selected)
        {
            if (isAble && Player_Stat.instance.stamina <= 0f)
            {
                if(Random.Range(0, 10) == 0)
                {
                    isAble = false;
                    Player_Stat.instance.stamina = Player_Stat.instance.DefaultStaminaMax;      //스테미나를 다시 최대치로 채워줌
                    StartCoroutine("CoolTime");
                }
                else
                {
                    isAble = false;
                    StartCoroutine("CoolTime");
                }
            }
        }
    }

    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(10f);
        isAble = true;
    }
}
