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
        this.Skill_Name = "태권도";
        this.Skill_Desc = "K 키를 눌러 주변의 적에게 5의 데미지를 주고 강하게 밀어낸다.";
        PlayerCache = Player;
    }

    
    void Update()
    {
        if (this.Selected)
        {
            // # 재사용 대기시간은 생각중
            if (Input.GetKeyDown(KeyCode.K) && Player_Stat.instance.stamina >= 20)
            {
                Player_Stat.instance.stamina -= 20;
                // # 플레이어를 따라오는 상태의 적은 Eneny가 아니라 EnemyChasing이다.   주의하자.
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
