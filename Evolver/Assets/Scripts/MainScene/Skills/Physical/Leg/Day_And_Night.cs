using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_And_Night :Physical_Manager
{
    float Original_MoveSpeed;   float Original_Dodge;   float DefaultMoveSpeed; float DefaultDodge;
    public GameObject Player;
    GameObject PlayerCache;
    bool isDay; bool isNight;   bool DayOnce;   bool NightOnce;
    void Start()
    {
        this.Skill_Num = 9;
        this.Skill_Name = "���� ��";
        //this.Sprite_Num = 
        this.Skill_Desc = "���� ���� 8�ʸ� �ֱ�� ��ü�Ǹ� �÷��̾�� �̷ο� ȿ���� �ش�. �� : �̵��ӵ��� 1 ������Ų��. �� : ȸ������ 5% ������Ų��.";
        PlayerCache = Player;
        isDay = true;
        Original_MoveSpeed = Player_Stat.instance.moveSpeed;
        Original_Dodge = Player_Stat.instance.missPercent;
    }

   
    void Update()
    {
        if (this.Selected)
        {
            if (PlayerCache.layer == LayerMask.NameToLayer("PlayerInShelter"))
            {
                Original_MoveSpeed = Player_Stat.instance.moveSpeed;
                Original_Dodge = Player_Stat.instance.missPercent;
            }
            else
            {
                if (isDay && !DayOnce)
                {
                    DayOnce = true;
                    Player_Stat.instance.moveSpeed += 1f;
                    StartCoroutine("Day");
                }
                else if (isNight && !NightOnce)
                {
                    NightOnce = true;
                    Player_Stat.instance.missPercent += 5f;
                    StartCoroutine("Night");
                }
            }
        }
       
    }

    IEnumerator Day()
    {
        yield return new WaitForSeconds(8f);
        // # �ٸ� ������ �̵��ӵ��� �������� ��� ������ �ʱ�ȭ���� �ʰ� �ϱ� ���� ���ǹ�
        Player_Stat.instance.moveSpeed = Original_MoveSpeed;
        isDay = false;
        isNight = true;
        DayOnce = false;
    }
    
    IEnumerator Night()
    {
        yield return new WaitForSeconds(8f);
        Player_Stat.instance.missPercent = Original_Dodge;
        isNight = false;
        isDay = true;
        NightOnce = false;
    }
}
