using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor_Agility : Physical_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    float OriginalMoveSpeed;
    void Start()
    {
        this.Skill_Num = 8;
        this.Sprite_Num = 10;
        this.Skill_Name = "순발력";
        this.Skill_Desc = "적의 공격을 피했을 경우 이동속도가 5초간 1 증가한다.";
        PlayerCache = Player;
        OriginalMoveSpeed = Player_Stat.instance.moveSpeed;
    }

    
    void Update()
    {
        if (this.Selected)
        {
            if (PlayerCache.layer == LayerMask.NameToLayer("PlayerInShelter"))
                OriginalMoveSpeed = Player_Stat.instance.moveSpeed;
            else
            {
                if (PlayerCache.GetComponent<Player>().isDodge)
                {
                    //PlayerCache.GetComponent<Player>().isDodge = false;   여기서 꺼버리면 다른 스킬은 해당 변수를 이용할 수 없다.
                    Player_Stat.instance.moveSpeed += 1;
                    StartCoroutine("SpeedUp");
                }
            }
        }
    }

    IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(5f);                        // 가비지 생성이 많을 것이므로 캐싱하는 방법을 시도해보자.
        Player_Stat.instance.moveSpeed = OriginalMoveSpeed;     // 이동속도 원위치
    }
}
