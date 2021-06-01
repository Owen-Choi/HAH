using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double_Income : Physical_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    bool isOnce;
    void Start()
    {
        this.Skill_Num = 32;
        //this.Sprite_Num =
        this.Skill_Name = "Double Income";
        this.Skill_Desc = "";
        PlayerCache = Player;
    }

    
    void Update()
    {
        if (this.Selected)
        {
            if(!isOnce && PlayerCache.GetComponent<Player>().isDodge)   //isDodge�� Player ��ũ��Ʈ���� �� �������� ��ٸ��� �ڷ�ƾ �Լ��� ���� ����ȴ�. ���� ������� �ʴ´ٸ� �ڷ�ƾ ��⸦ �÷�����.
            {
                isOnce = true;
                Player_Stat.instance.health += 5f;              //��ġ ���� �뷱�� �������� ���� ����
            }

            if (isOnce && !PlayerCache.GetComponent<Player>().isDodge)  //����ȭ ���� isOnce ���ǹ��� �տ� ��ġ
                isOnce = false;
        }
    }
}
