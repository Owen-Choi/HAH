using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patience : Skill_Manager
{
    public GameObject FireArrowShotPoint;
    GameObject ShotPointCache;
    float hold;
    float Original_Recovery;
    bool isOnce;
    public GameObject Player;
    GameObject PlayerCache;
    void Start()
    {
        this.Skill_Num = 32;
        this.Skill_Name = "인내심";
        //this.Sprite_Num =
        this.Skill_Desc = "4초동안 공격하지 않을 경우 스테미나 회복속도가 증가한다.";
        ShotPointCache = FireArrowShotPoint;
        PlayerCache = Player;
        Original_Recovery = Player_Stat.instance.Stamina_recovery_speed;            //최초에 한번 값을 먼저 넣어준다.
    }

    
    void Update()
    {
        if (this.Selected)
        {
            if (!ShotPointCache.GetComponent<Fire_Arrow_ShotPoint>().isShoot)
            {
                hold += Time.deltaTime;
            }
            if (ShotPointCache.GetComponent<Fire_Arrow_ShotPoint>().isShoot)
            {
                hold = 0f;
                Player_Stat.instance.Stamina_recovery_speed = Original_Recovery;
                isOnce = false;
                ShotPointCache.GetComponent<Fire_Arrow_ShotPoint>().isShoot = false;
            }

            if(hold > 4f && !isOnce)
            {
                isOnce = true;
                Player_Stat.instance.Stamina_recovery_speed += 3f;
            }

            if(PlayerCache.layer == LayerMask.NameToLayer("PlayerInShelter"))
            {
                Original_Recovery = Player_Stat.instance.Stamina_recovery_speed;            //수치의 변경이 있을 수도 있는 쉘터에서는 지속적으로 값을 업데이트
            }    
        }
    }
}
