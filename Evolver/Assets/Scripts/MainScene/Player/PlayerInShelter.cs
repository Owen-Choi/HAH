using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInShelter : MonoBehaviour
{
    Rigidbody2D rigid; 
    Animator anim;
    float h; public bool hDown; public bool hUp; public bool vDown; public bool vUp;
    float v;
    bool isHorizonMove;
    SpriteRenderer spriteRenderer;

    //�÷��̾ ���Ϳ� ���� �� �� ��ũ��Ʈ�� ����ȴ�.
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        hDown = Input.GetButtonDown("Horizontal");
        hUp = Input.GetButtonUp("Horizontal");
        vDown = Input.GetButtonDown("Vertical");
        vUp = Input.GetButtonUp("Vertical");

        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;


        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetBool("isHorizon", isHorizonMove);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetBool("isVertical", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("isChange", false);
            anim.SetBool("isVertical", false);
            anim.SetBool("isHorizon", false);
        }

    }

    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Player_Stat.instance.moveSpeed;
    }
    //�� ��ȯ üũ�� �÷��̾ �ƴ϶� ������Ʈ���� �ϴ°ɷ�    
}
