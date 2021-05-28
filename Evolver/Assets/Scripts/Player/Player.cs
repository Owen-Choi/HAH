using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public static bool isHideWeapon;            bool isLight;
    Rigidbody2D rigid;                          bool isSilver;                     bool isFire;
    Animator anim;
    float h;            public bool hDown;  public bool hUp;    public bool vDown;  public bool vUp; public bool DashMaster;    //질주의 달인 스킬 체크를 위한 변수
    float v;            public bool Can_Dash;   public int dashCool;    public float DashTime;
    bool isHorizonMove;
    SpriteRenderer spriteRenderer;
    public bool isDash;
    public float TimeForDash = 0.0f;
    public float TimeForDamaged = 0.0f;
    public GameObject Enemy;
    public bool isThorn;
    protected Color color;
    //맵핑중인 플레이어에게 적용되는 스크립트

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        Can_Dash = true;                                     
        dashCool = Player_Stat.instance.dashCool;
        DashTime = Player_Stat.instance.DashTime;
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
        //질주의 달인 스킬 체크를 확인하는 조건문. 좀 많이 비효율적이긴 하다.
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
            if (TimeForDash > DashTime)                 //일단은 Coroutine 말고 델타 타임으로 처리했다. 문제 생기면 수정해야함!
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

        if (Player_Stat.instance.isShelter)
        {   // # 쉘터라면 더 이상 방사능 수치와 목마름 수치가 증가하지 않는다.
            CancelInvoke("StackThirsty");
            CancelInvoke("StackRadioActive");
        }
        else
        {   // # 쉘터가 아니라면 방사능과 목마름 수치 점차 증가
            StackThirsty();
            StackRadioActive();
        }
    }

    void FixedUpdate()
    {
            Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        
        if (!isDash)
            rigid.velocity = moveVec * Player_Stat.instance.moveSpeed;
        else
            rigid.velocity = moveVec * Player_Stat.instance.moveSpeed * Player_Stat.instance.speedForDash;

        if (Input.GetMouseButton(0))
            rigid.velocity = moveVec * Player_Stat.instance.moveSpeed * Player_Stat.instance.SlowForCharge;           //경량화살 스킬 투자 시 SlowForCharge 값을 1로 바꿔주기

    }

    void StackThirsty()
    {
        Player_Stat.instance.Max_Stamina--;
        Invoke("StackThirsty", 30f);                        //30초마다 목마름 스택 추가
    }
    public void StackRadioActive()
    {
        Player_Stat.instance.RadioActive++;
        Player_Stat.instance.healthMax--;                   //may cause some errors. pay attention to it
        Invoke("StackRadioActive", 40f);                    //20초마다 방사능 스택 추가 #수정 : 20초는 너무 빠르다. 40초로 수정
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (this.gameObject.layer == LayerMask.NameToLayer("Player_Damaged"))
                return;

            if (isThorn)                                    //경량화살 스킬 가시 관련 코드. 비효율적이다.
            {
                if (Random.Range(0, 100) < 100)
                    Destroy(collision.gameObject);
            }

            if (Random.Range(1, 100) < Player_Stat.instance.missPercent)      //회피했을 시
            {
                this.gameObject.layer = LayerMask.NameToLayer("Player_Damaged");
                Debug.Log("회피");
            }
            else
            {
                //CameraShake.instance.cameraShake();   카메라 쉐이크 효과도 일단 삭제.
                Player_Stat.instance.health -= (collision.gameObject.GetComponent<Zombie_Stat>().Power - Player_Stat.instance.armor);
                //순간이동 급으로 발동되는 넉백코드 일단 삭제, 좀 더 부드럽게 피격 효과 줄 수 있는 방법 생각해보기
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
        yield return new WaitForSeconds(dashCool);          //이게 될 지 모르겠다.
        Can_Dash = true;
    }
    IEnumerator DashCoolForMaster()
    {
        yield return new WaitForSeconds(dashCool - 10);
        Can_Dash = true;
    }
}

