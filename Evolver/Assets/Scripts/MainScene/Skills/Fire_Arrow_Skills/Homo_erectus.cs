using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homo_erectus : Skill_Manager
{
    public GameObject Kitchen;
    bool ForOnce;
    void Start()
    {
        this.Skill_Num = 30;
        this.Sprite_Num = 2;
        this.Skill_Name = "ȣ�� ��������";
        this.Skill_Desc = "�ķ��� �� ���� ������� �����ش�.";
        ForOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Selected && !ForOnce)
        {
            ForOnce = true;
            Kitchen.GetComponent<Kitchen>().StarvationDecrease += 10;
        }
    }
}