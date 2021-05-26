using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meditation : Physical_Manager
{

    private void Awake()
    {
        this.Skill_Num = 43;
        this.Sprite_Num = 12;
        this.Skill_Name = "Meditation";
        this.Skill_Desc = "All stats will be slightly increased ";
    }
    void Update()
    {
        // # 명상으로는 능력치의 한계 없이 계속해서 올릴 수 있다. 하지만 값의 증가가 굉장히 미세하다.
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.damage += 3f;
            Player_Stat.instance.armor += 3f;
            Player_Stat.instance.criticalPercent += 3f;
            Player_Stat.instance.criticalDamage += 7f;
            Player_Stat.instance.missPercent += 3f;
            Player_Stat.instance.moveSpeed += 0.2f;
            // # 더 추가할 능력치는 필요에 따라 추가해주기
        }
    }
}
