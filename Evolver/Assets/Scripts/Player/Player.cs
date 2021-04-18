using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;
    public static bool isHideWeapon;            bool isLight;
    Rigidbody2D rigid;                          bool isSilver;                     bool isFire;
    Animator anim;
    float h;            public bool hDown;  public bool hUp;    public bool vDown;  public bool vUp; public bool DashMaster;    //������ ���� ��ų üũ�� ���� ����
    float v;            public bool Can_Dash;
    bool isHorizonMove;
    SpriteRenderer spriteRenderer;
    public bool isDash;
    public float TimeForDash = 0.0f;
    public float TimeForDamaged = 0.0f;
    public GameObject Enemy;
    protected Color color;


    private void Awake()
    {
        inventory = new Inventory();
    }
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        Can_Dash = true;
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

        if (vDown && v > 0)
            isHideWeapon = true;
        else if(v < 0 || isHorizonMove == true)
            isHideWeapon = false;


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
        //������ ���� ��ų üũ�� Ȯ���ϴ� ���ǹ�. �� ���� ��ȿ�����̱� �ϴ�.
        if(DashMaster && Input.GetKeyDown("space") && this.gameObject.layer != LayerMask.NameToLayer("Player_Damaged") && !Input.GetMouseButton(0) && Can_Dash)
        {
            Can_Dash = false;
            isDash = true;
            this.gameObject.layer = LayerMask.NameToLayer("Player_Dash");
            anim.SetBool("isDash", isDash);
            StartCoroutine("DashCoolForMaster");
        }
        else if(Input.GetKeyDown("space") && Player_Stat.instance.stamina > 30 && this.gameObject.layer != LayerMask.NameToLayer("Player_Damaged") && !Input.GetMouseButton(0) && Can_Dash)
        {
            Can_Dash = false;
            isDash = true;
            Player_Stat.instance.stamina -= 30;
            this.gameObject.layer = LayerMask.NameToLayer("Player_Dash");
            anim.SetBool("isDash", isDash);
            StartCoroutine("DashCoolForNotMaster");
        }

        if(isDash == true)
        {
            TimeForDash += Time.deltaTime;
            if (TimeForDash > 0.4f)                 //�ϴ��� Coroutine ���� ��Ÿ Ÿ������ ó���ߴ�. ���� ����� �����ؾ���!
            {
                isDash = false;
                TimeForDash = 0;
                this.gameObject.layer = LayerMask.NameToLayer("Player");
            }
            anim.SetBool("isDash", isDash);
        }

        if (Player_Stat.instance.health < 0)
            Destroy(gameObject);

        if (this.gameObject.layer == LayerMask.NameToLayer("Player_Damaged"))
            DamagedLayer();
    }

    void FixedUpdate()
    {
            Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        
        if (!isDash)
            rigid.velocity = moveVec * Player_Stat.instance.moveSpeed;
        else
            rigid.velocity = moveVec * Player_Stat.instance.moveSpeed * Player_Stat.instance.speedForDash;

        if (Input.GetMouseButton(0))
            rigid.velocity = moveVec * Player_Stat.instance.moveSpeed * Player_Stat.instance.SlowForCharge;           //�淮ȭ�� ��ų ���� �� SlowForCharge ���� 1�� �ٲ��ֱ�

    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (this.gameObject.layer == LayerMask.NameToLayer("Player_Damaged"))
                return;

            if (Random.Range(1, 100) < Player_Stat.instance.missPercent)      //ȸ������ ��
            {
                this.gameObject.layer = LayerMask.NameToLayer("Player_Damaged");
                Debug.Log("ȸ��");
            }
            else
            {
                CameraShake.instance.cameraShake();
                Player_Stat.instance.health -= (collision.gameObject.GetComponent<Zombie_Stat>().Power - Player_Stat.instance.armor);
                Vector2 difference = (transform.position - collision.transform.position) * 1.2f;
                transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
            }
            this.gameObject.layer = LayerMask.NameToLayer("Player_Damaged");

        }
    }
    void DamagedLayer()
    {
        color.a = 0.5f;
        spriteRenderer.color = color;
        color.a = 1f;
        TimeForDamaged += Time.deltaTime;
        if (TimeForDamaged > 1.3f)
        {
            this.gameObject.layer = LayerMask.NameToLayer("Player");
            spriteRenderer.color = color;
            TimeForDamaged = 0f;
        }
    }

    IEnumerator DashCoolForNotMaster() {
        yield return new WaitForSeconds(30f);
        Can_Dash = true;
    }
    IEnumerator DashCoolForMaster()
    {
        yield return new WaitForSeconds(20f);
        Can_Dash = true;
    }
}
