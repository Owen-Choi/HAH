using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor_Agility : Physical_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    float OriginalMoveSpeed;
    void Start()
    {
        this.Skill_Num = 8;
        this.Sprite_Num = 10;
        this.Skill_Name = "���߷�";
        this.Skill_Desc = "���� ������ ������ ��� �̵��ӵ��� 5�ʰ� 1 �����Ѵ�.";
        PlayerCache = Player;
        OriginalMoveSpeed = Player_Stat.instance.moveSpeed;
    }

    
    void Update()
    {
        if (this.Selected)
        {
            if (PlayerCache.layer == LayerMask.NameToLayer("PlayerInShelter"))
                OriginalMoveSpeed = Player_Stat.instance.moveSpeed;
            else
            {
                if (PlayerCache.GetComponent<Player>().isDodge)
                {
                    //PlayerCache.GetComponent<Player>().isDodge = false;   ���⼭ �������� �ٸ� ��ų�� �ش� ������ �̿��� �� ����.
                    Player_Stat.instance.moveSpeed += 1;
                    StartCoroutine("SpeedUp");
                }
            }
        }
    }

    IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(5f);                        // ������ ������ ���� ���̹Ƿ� ĳ���ϴ� ����� �õ��غ���.
        Player_Stat.instance.moveSpeed = OriginalMoveSpeed;     // �̵��ӵ� ����ġ
    }
}
