using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_AI_For_TypeC : MonoBehaviour
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
    float Original_MoveSpeed; bool isOnce;
    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        PlayerCopy = GameObject.Find("Player").GetComponent<Transform>();
        MoveSpeed = 2f;
        //MoveAI();
    }

    void Update()
    {
        int layerMask = (1 << LayerMask.NameToLayer("Player")) | (1 << LayerMask.NameToLayer("Player_Damaged") | (1 << LayerMask.NameToLayer("Player_Dash")) | 1 << LayerMask.NameToLayer("Player_Defense"));
        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, layerMask);

        //애니메이터는 정말 이해가 안간다. 조건에 안맞을 때 강제로 애니메이션을 실행시켜줘야 실행이 된다;;

        if (circle.collider)
        {
            // # 화상 레이어와 겹칠 경우 화상 레이어가 취소되기에 취한 조치. 문제점이 많아보인다.
            if (!isOnce)
            {
                isOnce = true;
                this.gameObject.layer = LayerMask.NameToLayer("EnemyChasing");
            }
            
            if (GetAngle() > 0f && GetAngle() <= 1.5f)
            {
                // # 결국 애니메이션 플레이는 내가 해주는데 변수를 바꿔줄 필요가 있을까?
                if (GetAngle() <= 0.75f)         //우측 상단 오른쪽을 향할 때
                {
                    anim.Play("Basic_Zombie_TypeC_Right_Walking");
                }
                else
                {
                    anim.Play("Basic_Zombie_TypeC_Up_Walking");
                }
            }
            else if (GetAngle() >= 1.5f && GetAngle() < 3.0f)
            {
                if (GetAngle() >= 2.25f)         //좌측 상단 왼쪽을 향할 때
                {
                    anim.Play("Basic_Zombie_TypeC_Left_Walking");
                }
                else
                {
                    anim.Play("Basic_Zombie_TypeC_Up_Walking");
                }
            }
            else if (GetAngle() > -3.0f && GetAngle() <= -1.5f)
            {

                if (GetAngle() <= -2.25f)        //좌측 하단 왼쪽을 향할 때
                {
                    anim.Play("Basic_Zombie_TypeC_Left_Walking");
                }
                else
                {
                    anim.Play("Basic_Zombie_TypeC_Down_Walking");
                }
            }
            else if (GetAngle() > -1.5f && GetAngle() <= 0f)
            {

                if (GetAngle() <= -0.75f)        //우측 하단 오른쪽을 향할 때
                {
                    anim.Play("Basic_Zombie_TypeC_Right_Walking");
                }
                else
                { 
                    anim.Play("Basic_Zombie_TypeC_Down_Walking");
                }
            }

            this.transform.position = Vector3.MoveTowards(this.transform.position, PlayerCopy.position, MoveSpeed * Time.deltaTime);
        }
        /*else
            this.gameObject.layer = LayerMask.NameToLayer("Enemy"); */          //일단은 보류. 스토커 스킬에서 적을 기습해도 이 코드 때문에 레이어가 바뀌지 않는다.

        if (this.gameObject.layer == LayerMask.NameToLayer("EnemyChasing"))
            radius *= 2;

        // # 네이팜 탄 스킬 체크를 위한 코드. 정말 비효율적이다.

        if (Player_Stat.instance.isNapalm2)
        {
            Original_MoveSpeed = this.MoveSpeed;
            if ((this.gameObject.layer == LayerMask.NameToLayer("Servant_Burned") || this.gameObject.layer == LayerMask.NameToLayer("Master_Burned")))
            {
                this.MoveSpeed = 1.5f;  //만약 적의 이동속도를 바꾸는 스킬이나 시스템이 생긴다면 변수를 만들어주러 와야한다.
            }
            else
                this.MoveSpeed = Original_MoveSpeed;
        }

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
