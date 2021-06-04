using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : Skill_Manager
{
    public GameObject SilverArrowShotPoint; bool isOnce;
    void Start()
    {
        this.Skill_Num = 22;
        this.Skill_Name = "스토커";
        //this.Sprite_Num =
        this.Skill_Desc = "플레이어를 발견하지 못한 적에게 2배의 피해를 준다.";
    }

    
    void Update()
    {
        if (this.Selected && !isOnce)
        {
            isOnce = true;
            SilverArrowShotPoint.GetComponent<Silver_Arrow_ShotPoint>().isStalker = true;
            //this.enabled = false;               업데이트 함수만 끄는지는 모르겠다.   # 스크립트 자체가 꺼진다. 이건 일단 검토해보자.
        }
    }
}
