using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meditation : Physical_Manager
{

    private void Awake()
    {
        this.Skill_Num = 43;
        this.Sprite_Num = 1;
        this.Skill_Name = "���";
        this.Skill_Desc = "��� �ɷ�ġ�� �ణ�� �����Ѵ�. (���ݷ�, ����, ġ��Ÿ Ȯ�� 2�� ����, ġ��Ÿ ���ط� 5 ����, ȸ��Ȯ�� 3 ����, �̵��ӵ� 0.05 ����)";
    }
    void Update()
    {
        // # ������δ� �ɷ�ġ�� �Ѱ� ���� ����ؼ� �ø� �� �ִ�. ������ ���� ������ ������ �̼��ϴ�.
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.damage += 2f;
            Player_Stat.instance.armor += 2f;
            Player_Stat.instance.criticalPercent += 2f;
            Player_Stat.instance.criticalDamage += 5f;
            Player_Stat.instance.missPercent += 3f;
            Player_Stat.instance.moveSpeed += 0.05f;
            // # �� �߰��� �ɷ�ġ�� �ʿ信 ���� �߰����ֱ�
        }
    }
}
