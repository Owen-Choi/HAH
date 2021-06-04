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
        this.Skill_Name = "접근 금지";
        this.Skill_Desc = "+ : 적에게 피격당했을 시 10%의 확률로 주위의 모든 적들을 밀어냄 ";
        PlayerCache = Player;
    }
    void Update()
    {
        if (this.Selected_First && !this.Selected_Second && !this.Selected_Last)
        {
            this.Skill_Desc = "+ : 적에게 피격당했을 시 20%의 확률로 주위의 모든 적들을 밀어내며 20의 피해를 준다. ";
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
            this.Skill_Desc = "+ : 적에게 피격당했을 시 20%의 확률로 주위의 모든 적들을 강하게 밀어내며 30의 피해를 준다. ";
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
