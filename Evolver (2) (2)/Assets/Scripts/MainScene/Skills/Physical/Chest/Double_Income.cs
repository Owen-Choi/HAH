using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double_Income : Physical_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    bool isOnce;
    void Start()
    {
        this.Skill_Num = 32;
        //this.Sprite_Num =
        this.Skill_Name = "일석이조";
        this.Skill_Desc = "적의 공격을 피할 경우 체력을 5 회복한다.";
        PlayerCache = Player;
    }

    
    void Update()
    {
        if (this.Selected)
        {
            if(!isOnce && PlayerCache.GetComponent<Player>().isDodge)   //isDodge는 Player 스크립트에서 한 프레임을 기다리는 코루틴 함수에 의해 변경된다. 만약 변경되지 않는다면 코루틴 대기를 늘려보자.
            {
                isOnce = true;
                Player_Stat.instance.health += 5f;              //수치 향후 밸런스 조정으로 변경 가능
            }

            if (isOnce && !PlayerCache.GetComponent<Player>().isDodge)  //최적화 위해 isOnce 조건문을 앞에 배치
                isOnce = false;
        }
    }
}
