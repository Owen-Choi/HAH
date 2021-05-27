using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refill_Stamina : Physical_Manager
{
    // # ��Ÿ�ϸ� ���׹̳��� ���� ���� ������ �����ϱ� ���� ���׹̳��� 50�ۼ�Ʈ �̻��� �Ѿ�� �ٽ� ��ȸ�� ����� �ý������� �������.
    bool isAble;

    private void Awake()
    {
        isAble = true;
        this.Skill_Num = 29;
        //this.Sprite_Num = 8;    
        this.Skill_Name = "Stamina re-fill";
        this.Skill_Desc = "if your stamina is zero, your stamina immediately jump to max value by 10 percent probability";
    }
    void Update()
    {
        if (this.Selected)
        {
            if (isAble && Player_Stat.instance.stamina <= 0f)
            {
                if(Random.Range(0, 10) == 0)
                {
                    isAble = false;
                    Player_Stat.instance.stamina = Player_Stat.instance.DefaultStaminaMax;      //���׹̳��� �ٽ� �ִ�ġ�� ä����
                    StartCoroutine("CoolTime");
                }
                else
                {
                    isAble = false;
                    StartCoroutine("CoolTime");
                }
            }
        }
    }

    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(10f);
        isAble = true;
    }
}
