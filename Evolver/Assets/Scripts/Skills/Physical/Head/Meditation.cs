using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meditation : Physical_Manager
{

    private void Awake()
    {
        this.Skill_Num = 43;
        this.Sprite_Num = 1;
        this.Skill_Name = "명상";
        this.Skill_Desc = "모든 능력치가 약간씩 증가한다. (공격력, 방어력, 치명타 확률 2씩 증가, 치명타 피해량 5 증가, 회피확률 3 증가, 이동속도 0.05 증가)";
    }
    void Update()
    {
        // # 명상으로는 능력치의 한계 없이 계속해서 올릴 수 있다. 하지만 값의 증가가 굉장히 미세하다.
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.damage += 2f;
            Player_Stat.instance.armor += 2f;
            Player_Stat.instance.criticalPercent += 2f;
            Player_Stat.instance.criticalDamage += 5f;
            Player_Stat.instance.missPercent += 3f;
            Player_Stat.instance.moveSpeed += 0.05f;
            // # 더 추가할 능력치는 필요에 따라 추가해주기
        }
    }
}
