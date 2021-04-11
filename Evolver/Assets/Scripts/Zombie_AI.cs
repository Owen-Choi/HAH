using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_AI : MonoBehaviour
{
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
        MoveAI();
    }

    void Update()
    {

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
            anim.SetBool("isChange", false);
        }

    }

    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(hMove, 0) : new Vector2(0, vMove);
        rigid.velocity = moveVec * MoveSpeed;
    }

    void MoveAI()
    {

        hMove = Random.Range(-1, 2);
        if (hMove == 0)
            vMove = Random.Range(-1, 2);
        term = Random.Range(1, 3);
        Invoke("MoveAI", term);

    }

   

}
