using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning_Cloak : Skill_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    public bool isOnce;
    void Start()
    {
        this.Skill_Num = 30;
        this.Skill_Name = "�¾��� ����";
        this.Skill_Desc = "���� �浹�� �� ���� ȭ����·� �����.";
        PlayerCache = Player;
    }

    
    void Update()
    {
        if (this.Selected && !isOnce)
        {
            isOnce = true;
            PlayerCache.GetComponent<Player>().isBurningCloak = true;
        }
    }
}
