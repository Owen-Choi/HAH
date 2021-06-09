using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taekwondo : Physical_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    Vector2 Direction;
    int i;
    void Start()
    {
        this.Skill_Num = 6;
        this.Sprite_Num = 8;
        this.Skill_Name = "�±ǵ�";
        this.Skill_Desc = "K Ű�� ���� �ֺ��� ������ 5�� �������� �ְ� ���ϰ� �о��.";
        PlayerCache = Player;
    }

    
    void Update()
    {
        if (this.Selected)
        {
            // # ���� ���ð��� ������
            if (Input.GetKeyDown(KeyCode.K) && Player_Stat.instance.stamina >= 20)
            {
                Player_Stat.instance.stamina -= 20;
                // # �÷��̾ ������� ������ ���� Eneny�� �ƴ϶� EnemyChasing�̴�.   ��������.
                RaycastHit2D[] circle = Physics2D.CircleCastAll(PlayerCache.transform.position, 1.5f, Vector2.up, 1.5f, LayerMask.GetMask("EnemyChasing"));
                if (circle[0])
                {
                    for (i = 0; i < circle.Length; i++)
                    {
                        Direction = (circle[i].transform.position - PlayerCache.transform.position).normalized;
                        circle[i].transform.GetComponent<Rigidbody2D>().AddForce(Direction * 5000);
                        circle[i].transform.GetComponent<Zombie_Stat>().Health -= 5;
                    }
                }
                CameraShake.instance.cameraShake();
            }
        }
    }
}
