using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_AI_For_TypeA : MonoBehaviour
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
    float Original_MoveSpeed;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        PlayerCopy = GameObject.Find("Player").GetComponent<Transform>();
        MoveSpeed = 1.4f;
    }

    void Update()
    {
        int layerMask = (1 << LayerMask.NameToLayer("Player")) | (1 << LayerMask.NameToLayer("Player_Damaged") | (1 << LayerMask.NameToLayer("Player_Dash")) | 1 << LayerMask.NameToLayer("Player_Defense"));
        RaycastHit2D circle = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, layerMask);

        //�ִϸ����ʹ� ���� ���ذ� �Ȱ���. ���ǿ� �ȸ��� �� ������ �ִϸ��̼��� ���������� ������ �ȴ�;;

        if (circle.collider)
        {
            this.gameObject.layer = LayerMask.NameToLayer("EnemyChasing");
            anim.SetFloat("HorizonValue", (PlayerCopy.position.x - this.transform.position.x));
            anim.SetFloat("VerticalValue", (PlayerCopy.position.y - this.transform.position.y));
            if (GetAngle() > 0f && GetAngle() <= 1.5f)
            {

                if (GetAngle() <= 0.75f)         //���� ��� �������� ���� ��
                {
                    anim.SetFloat("HorizonValue", (PlayerCopy.position.x - this.transform.position.x));
                    anim.SetFloat("VerticalValue", 0f);
                    anim.Play("Basic_Zombie_Right_Walking");
                }
                else
                {
                    anim.SetFloat("HorizonValue", 0f);
                    anim.SetFloat("VerticalValue", (PlayerCopy.position.y - this.transform.position.y));
                    anim.Play("Basic_Zombie_Up_Walking");
                }
            }
            else if (GetAngle() >= 1.5f && GetAngle() < 3.0f)
            {
                if (GetAngle() >= 2.25f)         //���� ��� ������ ���� ��
                {
                    anim.SetFloat("HorizonValue", (PlayerCopy.position.x - this.transform.position.x));
                    anim.SetFloat("VerticalValue", 0f);
                    anim.Play("Basic_Zombie_Left_Walking");
                }
                else
                {
                    anim.SetFloat("HorizonValue", 0f);
                    anim.SetFloat("VerticalValue", (PlayerCopy.position.y - this.transform.position.y));
                    anim.Play("Basic_Zombie_Up_Walking");
                }
            }
            else if (GetAngle() > -3.0f && GetAngle() <= -1.5f)
            {

                if (GetAngle() <= -2.25f)        //���� �ϴ� ������ ���� ��
                {
                    anim.SetFloat("HorizonValue", (PlayerCopy.position.x - this.transform.position.x));
                    anim.SetFloat("VerticalValue", 0f);
                    anim.Play("Basic_Zombie_Left_Walking");
                }
                else
                {
                    anim.SetFloat("HorizonValue", 0f);
                    anim.SetFloat("VerticalValue", (PlayerCopy.position.y - this.transform.position.y));
                    anim.Play("Basic_Zombie_Down_Walking");
                }
            }
            else if (GetAngle() > -1.5f && GetAngle() <= 0f)
            {

                if (GetAngle() <= -0.75f)        //���� �ϴ� �������� ���� ��
                {
                    anim.SetFloat("HorizonValue", (PlayerCopy.position.x - this.transform.position.x));
                    anim.SetFloat("VerticalValue", 0f);
                    anim.Play("Basic_Zombie_Right_Walking");
                }
                else
                {
                    anim.SetFloat("HorizonValue", 0f);
                    anim.SetFloat("VerticalValue", (PlayerCopy.position.y - this.transform.position.y));
                    anim.Play("Basic_Zombie_Down_Walking");
                }
            }

            this.transform.position = Vector3.MoveTowards(this.transform.position, PlayerCopy.position, MoveSpeed * Time.deltaTime);
        }
        /*else
            this.gameObject.layer = LayerMask.NameToLayer("Enemy");*/

        if (this.gameObject.layer == LayerMask.NameToLayer("EnemyChasing"))
            radius *= 2;

        if (Player_Stat.instance.isNapalm2)
        {
            Original_MoveSpeed = this.MoveSpeed;
            if ((this.gameObject.layer == LayerMask.NameToLayer("Servant_Burned") || this.gameObject.layer == LayerMask.NameToLayer("Master_Burned")))
            {
                this.MoveSpeed = 1f;  //���� ���� �̵��ӵ��� �ٲٴ� ��ų�̳� �ý����� ����ٸ� ������ ������ַ� �;��Ѵ�.
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
