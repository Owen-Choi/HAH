using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_AI : MonoBehaviour
{
    public Transform Player;
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
        //MoveAI();
    }

    void Update()
    {

        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, LayerMask.GetMask("Player"));

        //�ִϸ����ʹ� ���� ���ذ� �Ȱ���. ���ǿ� �ȸ��� �� ������ �ִϸ��̼��� ���������� ������ �ȴ�;;

        if (circle.collider.tag == "Player")                //���⵵ �����ߴ°� ��ƾ� ��.
        {
            anim.SetFloat("HorizonValue", (Player.position.x - this.transform.position.x));
            anim.SetFloat("VerticalValue", (Player.position.y - this.transform.position.y));
            if (GetAngle() > 0f && GetAngle() <= 1.5f)
            {

                if (GetAngle() <= 0.75f)         //���� ��� �������� ���� ��
                {
                    anim.SetFloat("HorizonValue", (Player.position.x - this.transform.position.x));
                    anim.SetFloat("VerticalValue", 0f);
                    anim.Play("Basic_Zombie_TypeB_Right_Walking");
                }
                else
                {
                    anim.SetFloat("HorizonValue", 0f);
                    anim.SetFloat("VerticalValue", (Player.position.y - this.transform.position.y));
                    anim.Play("Basic_Zombie_TypeB_Up_Walking");
                }
            }
            else if (GetAngle() >= 1.5f && GetAngle() < 3.0f)
            {
                if (GetAngle() >= 2.25f)         //���� ��� ������ ���� ��
                {
                    anim.SetFloat("HorizonValue", (Player.position.x - this.transform.position.x));
                    anim.SetFloat("VerticalValue", 0f);
                    anim.Play("Basic_Zombie_TypeB_Left_Walking");
                }
                else
                {
                    anim.SetFloat("HorizonValue", 0f);
                    anim.SetFloat("VerticalValue", (Player.position.y - this.transform.position.y));
                    anim.Play("Basic_Zombie_TypeB_Up_Walking");
                }
            }
            else if (GetAngle() > -3.0f && GetAngle() <= -1.5f)
            {

                if (GetAngle() <= -2.25f)        //���� �ϴ� ������ ���� ��
                {
                    anim.SetFloat("HorizonValue", (Player.position.x - this.transform.position.x));
                    anim.SetFloat("VerticalValue", 0f);
                    anim.Play("Basic_Zombie_TypeB_Left_Walking");
                }
                else
                {
                    anim.SetFloat("HorizonValue", 0f);
                    anim.SetFloat("VerticalValue", (Player.position.y - this.transform.position.y));
                    anim.Play("Basic_Zombie_TypeB_Down_Walking");
                }
            }
            else if (GetAngle() > -1.5f && GetAngle() <= 0f)
            {

                if (GetAngle() <= -0.75f)        //���� �ϴ� �������� ���� ��
                {
                    anim.SetFloat("HorizonValue", (Player.position.x - this.transform.position.x));
                    anim.SetFloat("VerticalValue", 0f);
                    anim.Play("Basic_Zombie_TypeB_Right_Walking");
                }
                else
                {
                    anim.SetFloat("HorizonValue", 0f);
                    anim.SetFloat("VerticalValue", (Player.position.y - this.transform.position.y));
                    anim.Play("Basic_Zombie_TypeB_Down_Walking");
                }
            }

            this.transform.position = Vector3.MoveTowards(this.transform.position, Player.position, MoveSpeed * Time.deltaTime);
        }
        else;
       
       
    }

    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(hMove, 0) : new Vector2(0, vMove);
        rigid.velocity = moveVec * MoveSpeed;
    }
    // AI ���� �� �������� �����̴� AI �Լ�
    /*void MoveAI()
    {

        if(Random.Range(0,100) < 30)
        {
            hMove = 0;
            vMove = 0;
            anim.SetBool("isIdle", true);
            Invoke("MoveAI", 2f);
        }
        else
        {
            if(Random.Range(0,2) == 0) {
                ;
            }
        }
        Invoke("MoveAI", term);

    } */       

        float GetAngle()
        {
            Vector3 difference = Player.position - transform.position;

            difference.Normalize();

            
            return degree = Mathf.Atan2(difference.y, difference.x);
            
        }

    }

