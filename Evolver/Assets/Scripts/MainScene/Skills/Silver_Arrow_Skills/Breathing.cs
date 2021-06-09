using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathing : Skill_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    float StandTime;
    float Original_RecoverSpeed;
    bool isOnce;
    void Start()
    {
        this.Skill_Num = 24;
        this.Skill_Name = "호흡";
        this.Skill_Desc = "2초 이상 움직이지 않고 가만히 있을 경우 스테미나의 회복 속도가 증가한다.";
        //this.Sprite_Num =
        PlayerCache = Player;
        Original_RecoverSpeed = Player_Stat.instance.Stamina_recovery_speed;
    }

    
    void Update()
    {
        if (this.Selected)
        {
            if (!PlayerCache.transform.hasChanged)                      //hasChanged 값이 false라면 움직임이 없는 상태. 이 상태가 2초간 지속되면 회복속도 증가
            {
                StandTime += Time.deltaTime;
                if(StandTime > 2f && !isOnce)
                {
                    isOnce = true;
                    Player_Stat.instance.Stamina_recovery_speed += 3f;
                }
            }
            else if (PlayerCache.transform.hasChanged)                  //플레이어의 움직임이 감지된다면
            {
                isOnce = false;
                StandTime = 0f;
                Player_Stat.instance.Stamina_recovery_speed = Original_RecoverSpeed;
                PlayerCache.transform.hasChanged = false;
            }



            if (PlayerCache.layer == LayerMask.NameToLayer("PlayerInShelter"))
            {
                Original_RecoverSpeed = Player_Stat.instance.Stamina_recovery_speed;        // 능력치의 변화가 생길 수도 있는 쉘터에서는 상시 값을 업데이트 해주도록 한다.
            }
        }
    }
}
