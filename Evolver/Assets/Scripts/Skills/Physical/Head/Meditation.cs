using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meditation : Physical_Manager
{
    void Update()
    {
        // # ������δ� �ɷ�ġ�� �Ѱ� ���� ����ؼ� �ø� �� �ִ�. ������ ���� ������ ������ �̼��ϴ�.
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.damage += 3f;
            Player_Stat.instance.armor += 3f;
            Player_Stat.instance.criticalPercent += 3f;
            Player_Stat.instance.criticalDamage += 7f;
            Player_Stat.instance.missPercent += 3f;
            Player_Stat.instance.moveSpeed += 0.2f;
            // # �� �߰��� �ɷ�ġ�� �ʿ信 ���� �߰����ֱ�
        }
    }
}
