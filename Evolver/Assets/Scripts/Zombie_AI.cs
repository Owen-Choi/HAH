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
        Debug.Log(circle);

        if (circle.collider.tag == "Player")
        {
            anim.SetFloat("HorizonValue", (Player.position.x - this.transform.position.x));
            anim.SetFloat("VerticalValue", (Player.position.y - this.transform.position.y));

           
            if (GetAngle() > 0 && GetAngle() <= 1.5f)
            {
                anim.SetBool("isChange", true);
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", true);
                anim.SetBool("isBack", true);
                
            }

            if (GetAngle() >= 1.5f && GetAngle() < 3.0f)
            {
                anim.SetBool("isChange", true);
                anim.SetBool("isRight", false);
                anim.SetBool("isLeft", true);
                anim.SetBool("isBack", true);
            }

            if (GetAngle() > -3.0f && GetAngle() <= -1.5f)
            {
                anim.SetBool("isChange", true);
                anim.SetBool("isRight", false);
                anim.SetBool("isLeft", true);
                anim.SetBool("isBack", false);
            }

            if (GetAngle() > -1.5f && GetAngle() <= 0f)
            {
                anim.SetBool("isChange", true);
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", true);
                anim.SetBool("isBack", false);
            }
            this.transform.position = Vector3.MoveTowards(this.transform.position, Player.position, MoveSpeed * Time.deltaTime);
        }
       

            if (hMove > 0 || hMove < 0)
                isHorizonMove = true;
            else if (hMove == 0)
                isHorizonMove = false;

        if (anim.GetInteger("HorizonValue") != hMove)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("HorizonValue", hMove);
        }
        else if (anim.GetInteger("VerticalValue") != vMove)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("VerticalValue", vMove);
        }
        else
        {
            //anim.SetBool("isChange", false);
        }

       
    }

    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(hMove, 0) : new Vector2(0, vMove);
        rigid.velocity = moveVec * MoveSpeed;
    }

    void MoveAI()
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

    } 

        float GetAngle()
        {
            Vector3 difference = Player.position - transform.position;

            difference.Normalize();


            return degree = Mathf.Atan2(difference.y, difference.x);

        }

    }

