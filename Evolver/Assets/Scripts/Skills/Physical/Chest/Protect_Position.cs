using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protect_Position : Physical_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    bool available;
    void Start()
    {
        this.Skill_Num = 31;
        this.Sprite_Num = 12;
        this.Skill_Name = "방어태세";
        this.Skill_Desc = "P 버튼을 눌러 스테미나 40을 소모하고 방어 태세에 들어간다. 방어태세에서는 적의 공격을 확정적으로 막을 수 있다.";
        PlayerCache = Player;
        available = true;

    }

    
    void Update()
    {
        if (this.Selected)
        {
            if (Input.GetKeyDown(KeyCode.P) && Player_Stat.instance.stamina >= 40 && available)
            {
                available = false;
                Player_Stat.instance.stamina -= 40;
                PlayerCache.layer = LayerMask.NameToLayer("Player_Defense");
            }
        }
    }
    // # 재사용 대기시간 40초
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(40f);
        available = true;

    }
}
