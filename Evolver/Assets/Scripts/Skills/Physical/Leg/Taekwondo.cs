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
        //this.Sprite_Num =
        this.Skill_Name = "Taekwondo";
        this.Skill_Desc = "If you use 20 stamina, you can push all of enemies around you with 5 damage, just press 'k' ";
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
                CameraShake.instance.cameraShake();
                RaycastHit2D[] circle = Physics2D.CircleCastAll(PlayerCache.transform.position, 1, Vector2.up, 1, LayerMask.GetMask("Enemy"));
                if (circle[0])
                {
                    for (i = 0; i < circle.Length; i++)
                    {
                        Direction = (circle[i].transform.position - PlayerCache.transform.position).normalized;
                        circle[i].transform.GetComponent<Rigidbody2D>().AddForce(Direction * 5000);
                        circle[i].transform.GetComponent<Zombie_Stat>().Health -= 5;
                    }
                }
            }
        }
    }
}
