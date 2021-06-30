using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Arrow : Skill_Manager
{
    public GameObject Explode;
    bool ChangeOnce;    bool ChangeTwice;   bool ChangeLast;
    public GameObject Fire_Arrow_ShotPoint;
    // Start is called before the first frame update
    void Start()
    {
        this.Skill_Num = 27;
        ChangeOnce = false;
        ChangeTwice = false;
        ChangeLast = false;
        this.Sprite_Num = 6;
        this.Skill_Name = "폭발성 화살";
        this.Skill_Desc = "화살이 치명타로 적용될 시 폭발하며 큰 피해를 입힌다.";
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Selected_First && !ChangeOnce)
        {
            Fire_Arrow_ShotPoint.GetComponent<Fire_Arrow_ShotPoint>().is_Explode = true;
            //Player_Stat.instance.criticalPercent -= 10;       원래는 치명타 확률을 10% 줄였지만 일단 보류해보자. 불화살이 너무 약하다.
            ChangeOnce = true;
            this.Sprite_Num = 7;
            this.Skill_Desc = "크리티컬 확률(화살이 폭발할 확률)이 5% 증가하며 모든 종류의 폭발 데미지가 50% 증가한다.";
        }

        if(this.Selected_Second && !ChangeTwice)
        {
            ChangeTwice = true;
            Player_Stat.instance.criticalPercent += 5;
            Player_Stat.instance.Explode_Multiple_Damage += 0.5f;
            this.Sprite_Num = 8;
            this.Skill_Desc = "모든 종류의 폭발 데미지가 50% 증가한다.";
        }

        if(this.Selected_Last && !ChangeLast)
        {
            this.Selected = true;
            ChangeLast = true;
            Player_Stat.instance.Explode_Multiple_Damage += 0.5f;
            return;
        }
    }
}
