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
        this.Skill_Name = "����¼�";
        this.Skill_Desc = "P ��ư�� ���� ���׹̳� 40�� �Ҹ��ϰ� ��� �¼��� ����. ����¼������� ���� ������ Ȯ�������� ���� �� �ִ�.";
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
    // # ���� ���ð� 40��
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(40f);
        available = true;

    }
}
