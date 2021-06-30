using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash_Arrow : Skill_Manager
{
    public GameObject SilverArrowShotPoint;
    GameObject SASP;
    bool isOnce;
    void Start()
    {
        this.Skill_Num = 20;
        this.Sprite_Num = 10;
        this.Skill_Name = "고속화살";
        this.Skill_Desc = "고속의 화살에 적들이 화상을 입는다 : 치명타가 70%의 확률로 화상을 일으킨다.";
        SASP = SilverArrowShotPoint;
        isOnce = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Selected && isOnce)
        {
            isOnce = false;
            SASP.GetComponent<Silver_Arrow_ShotPoint>().isFlash = true;
        }
    }
}
