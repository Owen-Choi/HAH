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
        //this.Sprite_Num = 
        this.Skill_Name = "Motor Agility";
        this.Skill_Desc = "Your movement speed will be temporariliy increased when you dodge enemy's attack ";
        PlayerCache = Player;
    }

    
    void Update()
    {
        if (this.Selected)
        {
            if (PlayerCache.GetComponent<Player>().isDodge)
            {
                PlayerCache.GetComponent<Player>().isDodge = false;
                OriginalMoveSpeed = Player_Stat.instance.moveSpeed;
                Player_Stat.instance.moveSpeed += 2;
                StartCoroutine("SpeedUp");
            }
        }
    }

    IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(5f);                    // ������ ������ ���� ���̹Ƿ� ĳ���ϴ� ����� �õ��غ���.
        Player_Stat.instance.moveSpeed = OriginalMoveSpeed;     // �̵��ӵ� ����ġ
    }
}
