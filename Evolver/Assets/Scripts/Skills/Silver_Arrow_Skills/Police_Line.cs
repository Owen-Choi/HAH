using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police_Line : Skill_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    bool isOnce;
    Vector2 Direction;
    int i;
    private void Awake()
    {
        this.Skill_Num = 21;
        //this.Sprite_Num =
        this.Skill_Name = "���� ����";
        this.Skill_Desc = "+ : ������ �ǰݴ����� �� 10%�� Ȯ���� ������ ��� ������ �о ";
        PlayerCache = Player;
    }
    void Update()
    {
        if (this.Selected_First && !this.Selected_Second && !this.Selected_Last)
        {
            this.Skill_Desc = "+ : ������ �ǰݴ����� �� 20%�� Ȯ���� ������ ��� ������ �о�� 20�� ���ظ� �ش�. ";
            if (PlayerCache.gameObject.layer == LayerMask.NameToLayer("Player_Damaged") && !isOnce)
            {
                isOnce = true;
                if (Random.Range(0, 100) < 10)
                {
                    RaycastHit2D[] circle = Physics2D.CircleCastAll(PlayerCache.transform.position, 1, Vector2.up, 1, LayerMask.GetMask("EnemyChasing"));
                    if (circle[0])
                    {
                        for (i = 0; i < circle.Length; i++)
                        {
                            Direction = (circle[i].transform.position - PlayerCache.transform.position).normalized;
                            circle[i].transform.GetComponent<Rigidbody2D>().AddForce(Direction * 3500);
                        }
                    }
                }
            }
        }

        if(this.Selected_First && this.Selected_Second && !this.Selected_Last)
        {
            this.Skill_Desc = "+ : ������ �ǰݴ����� �� 20%�� Ȯ���� ������ ��� ������ ���ϰ� �о�� 30�� ���ظ� �ش�. ";
            if (PlayerCache.gameObject.layer == LayerMask.NameToLayer("Player_Damaged") && !isOnce)
            {
                isOnce = true;
                if (Random.Range(0, 100) < 20)
                {
                    RaycastHit2D[] circle = Physics2D.CircleCastAll(PlayerCache.transform.position, 1, Vector2.up, 1, LayerMask.GetMask("EnemyChasing"));
                    if (circle[0])
                    {
                        for (i = 0; i < circle.Length; i++)
                        {
                            Direction = (circle[i].transform.position - PlayerCache.transform.position).normalized;
                            circle[i].transform.GetComponent<Rigidbody2D>().AddForce(Direction * 3500);
                            circle[i].transform.GetComponent<Zombie_Stat>().Health -= 20;
                        }
                    }
                }
            }
        }

        if(this.Selected_First && this.Selected_Second && this.Selected_Last)
        {
            if (PlayerCache.gameObject.layer == LayerMask.NameToLayer("Player_Damaged") && !isOnce)
            {
                isOnce = true;
                if (Random.Range(0, 100) < 20)
                {
                    RaycastHit2D[] circle = Physics2D.CircleCastAll(PlayerCache.transform.position, 1, Vector2.up, 1, LayerMask.GetMask("EnemyChasing"));
                    if (circle[0])
                    {
                        for (i = 0; i < circle.Length; i++)
                        {
                            Direction = (circle[i].transform.position - PlayerCache.transform.position).normalized;
                            circle[i].transform.GetComponent<Rigidbody2D>().AddForce(Direction * 5000);
                            circle[i].transform.GetComponent<Zombie_Stat>().Health -= 30;
                        }
                    }
                }
            }
        }

        if (PlayerCache.gameObject.layer != LayerMask.NameToLayer("Player_Damaged"))
            isOnce = false;
    }
}
