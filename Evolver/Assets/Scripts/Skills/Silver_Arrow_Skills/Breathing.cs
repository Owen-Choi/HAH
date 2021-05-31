using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathing : Skill_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    float StandTime;
    float Original_RecoverSpeed;
    void Start()
    {
        this.Skill_Num = 24;
        this.Skill_Name = "Breathing";
        //this.Sprite_Num =
        PlayerCache = Player;
    }

    
    void Update()
    {
        if (this.Selected)
        {
            if (!PlayerCache.transform.hasChanged)                      //hasChanged 값이 false라면 움직임이 없는 상태. 이 상태가 2초간 지속되면 회복속도 증가
            {
                StandTime += Time.deltaTime;
                if(StandTime > 2f)
                {
                    Player_Stat.instance.Stamina_recovery_speed += 3f;
                }
            }
            else if (PlayerCache.transform.hasChanged)                  //플레이어의 움직임이 감지된다면
            {
                StandTime = 0f;
                Player_Stat.instance.Stamina_recovery_speed = Original_RecoverSpeed;
            }



            if (PlayerCache.layer == LayerMask.NameToLayer("PlayerInShelter"))
            {
                Original_RecoverSpeed = Player_Stat.instance.Stamina_recovery_speed;        // 능력치의 변화가 생길 수도 있는 쉘터에서는 상시 값을 업데이트 해주도록 한다.
            }
        }
    }
}
