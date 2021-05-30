using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_AI : MonoBehaviour
{
    public Transform PlayerCopy;
    public float radius; float degree;
    public int hMove;
    public int vMove;
    int term;
    bool isHorizonMove;
    Rigidbody2D rigid;
    Animator anim;
    public float MoveSpeed;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        PlayerCopy = GameObject.Find("Player").GetComponent<Transform>();
        //MoveAI();
    }

    void Update()
    {
        int layerMask = (1 << LayerMask.NameToLayer("Player")) | (1 << LayerMask.NameToLayer("Player_Damaged") | (1 << LayerMask.NameToLayer("Player_Dash")) | 1 << LayerMask.NameToLayer("Player_Defense"));
        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, layerMask);

        //애니메이터는 정말 이해가 안간다. 조건에 안맞을 때 강제로 애니메이션을 실행시켜줘야 실행이 된다;;

        if (circle.collider)
        {
            this.gameObject.layer = LayerMask.NameToLayer("EnemyChasing");
            anim.SetFloat("HorizonValue", (PlayerCopy.position.x - this.transform.position.x));
            anim.SetFloat("VerticalValue", (PlayerCopy.position.y - this.transform.position.y));
            if (GetAngle() > 0f && GetAngle() <= 1.5f)
            {

                if (GetAngle() <= 0.75f)         //우측 상단 오른쪽을 향할 때
                {
                    anim.SetFloat("HorizonValue", (PlayerCopy.position.x - this.transform.position.x));
                    anim.SetFloat("VerticalValue", 0f);
                    anim.Play("Basic_Zombie_TypeB_Right_Walking");
                }
                else
                {
                    anim.SetFloat("HorizonValue", 0f);
                    anim.SetFloat("VerticalValue", (PlayerCopy.position.y - this.transform.position.y));
                    anim.Play("Basic_Zombie_TypeB_Up_Walking");
                }
            }
            else if (GetAngle() >= 1.5f && GetAngle() < 3.0f)
            {
                if (GetAngle() >= 2.25f)         //좌측 상단 왼쪽을 향할 때
                {
                    anim.SetFloat("HorizonValue", (PlayerCopy.position.x - this.transform.position.x));
                    anim.SetFloat("VerticalValue", 0f);
                    anim.Play("Basic_Zombie_TypeB_Left_Walking");
                }
                else
                {
                    anim.SetFloat("HorizonValue", 0f);
                    anim.SetFloat("VerticalValue", (PlayerCopy.position.y - this.transform.position.y));
                    anim.Play("Basic_Zombie_TypeB_Up_Walking");
                }
            }
            else if (GetAngle() > -3.0f && GetAngle() <= -1.5f)
            {

                if (GetAngle() <= -2.25f)        //좌측 하단 왼쪽을 향할 때
                {
                    anim.SetFloat("HorizonValue", (PlayerCopy.position.x - this.transform.position.x));
                    anim.SetFloat("VerticalValue", 0f);
                    anim.Play("Basic_Zombie_TypeB_Left_Walking");
                }
                else
                {
                    anim.SetFloat("HorizonValue", 0f);
                    anim.SetFloat("VerticalValue", (PlayerCopy.position.y - this.transform.position.y));
                    anim.Play("Basic_Zombie_TypeB_Down_Walking");
                }
            }
            else if (GetAngle() > -1.5f && GetAngle() <= 0f)
            {

                if (GetAngle() <= -0.75f)        //우측 하단 오른쪽을 향할 때
                {
                    anim.SetFloat("HorizonValue", (PlayerCopy.position.x - this.transform.position.x));
                    anim.SetFloat("VerticalValue", 0f);
                    anim.Play("Basic_Zombie_TypeB_Right_Walking");
                }
                else
                {
                    anim.SetFloat("HorizonValue", 0f);
                    anim.SetFloat("VerticalValue", (PlayerCopy.position.y - this.transform.position.y));
                    anim.Play("Basic_Zombie_TypeB_Down_Walking");
                }
            }

            this.transform.position = Vector3.MoveTowards(this.transform.position, PlayerCopy.position, MoveSpeed * Time.deltaTime);
        }
        /*else
            this.gameObject.layer = LayerMask.NameToLayer("Enemy"); */          //일단은 보류. 스토커 스킬에서 적을 기습해도 이 코드 때문에 레이어가 바뀌지 않는다.

        if (this.gameObject.layer == LayerMask.NameToLayer("EnemyChasing"))
            radius *= 2;

    }

    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(hMove, 0) : new Vector2(0, vMove);
        rigid.velocity = moveVec * MoveSpeed;
    }
  
        float GetAngle()
        {
            Vector3 difference = PlayerCopy.position - transform.position;

            difference.Normalize();

            
            return degree = Mathf.Atan2(difference.y, difference.x);
            
        }


}

