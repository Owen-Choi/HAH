using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public static bool isHideWeapon;            bool isLight;
    Rigidbody2D rigid;                          bool isSilver;                     bool isFire;
    Animator anim;
    float h;            public bool hDown;  public bool hUp;    public bool vDown;  public bool vUp; public bool DashMaster;    //질주의 달인 스킬 체크를 위한 변수
    float v;            public bool Can_Dash;   public int dashCool;    public float DashTime;  public bool isDodge;
    bool isHorizonMove;
    SpriteRenderer spriteRenderer;
    public bool isDash;
    public float TimeForDash = 0.0f;
    public float TimeForDamaged = 0.0f;
    public GameObject Enemy;
    public bool isThorn;    public bool isBurningCloak;
    protected Color color;
    public GameObject DashIcon;
    GameObject DashIconCache;   Color available;    Color unavailable;
   
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        Can_Dash = true;                                     
        dashCool = Player_Stat.instance.dashCool;
        DashTime = Player_Stat.instance.DashTime;
        DashIconCache = DashIcon;
        available.r = unavailable.r = 255;
        available.g = unavailable.g = 255;
        available.b = unavailable.b = 255;
        available.a = 1f;   unavailable.a = 0f;
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
        if(DashMaster && Input.GetKeyDown("space") && this.gameObject.layer == LayerMask.NameToLayer("Player") && !Input.GetMouseButton(0) && Can_Dash)
        {
            DashIconCache.GetComponent<Image>().color = unavailable;
            Can_Dash = false;
            isDash = true;
            this.gameObject.layer = LayerMask.NameToLayer("Player_Dash");
            anim.SetBool("isDash", isDash);
            StartCoroutine("DashCoolForMaster");
        }
        else if(Input.GetKeyDown("space") && Player_Stat.instance.stamina > 30 && this.gameObject.layer == LayerMask.NameToLayer("Player") && !Input.GetMouseButton(0) && Can_Dash)
        {
            DashIconCache.GetComponent<Image>().color = unavailable;
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

    public void StackThirsty()
    {
        Player_Stat.instance.thirsty++;                 
        Invoke("StackThirsty", 100f);                                                                //100초로 변경, 쉘터에서도 예외 없음
    }

    public void StackRadioActive()
    {
        Player_Stat.instance.RadioActive++;
        // 최대 체력 감소는 Player_Stat 스크립트에서 실행하겠다.
        Invoke("StackRadioActive", 40f);                                                            //20초마다 방사능 스택 추가 #수정 : 20초는 너무 빠르다. 40초로 수정
    }
    public void StopRadioActive()
    {
        CancelInvoke("StackRadioActive");
    }

    public void StackStarvation()
    {
        Player_Stat.instance.Starvation++;
        Invoke("StackStarvation", 100f);                                                            //갈증과 마찬가지로 쉘터에서도 예외 없음
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (this.gameObject.layer == LayerMask.NameToLayer("Player_Damaged") || this.gameObject.layer == LayerMask.NameToLayer("Player_Defense"))
            {
                if (this.gameObject.layer == LayerMask.NameToLayer("Player_Defense"))
                    this.gameObject.layer = LayerMask.NameToLayer("Player_Damaged");                //방어태세 해제
                return;
            }

            if (isThorn)                                                                            //경량화살 스킬 가시 관련 코드. 비효율적이다.
            {
                if (Random.Range(0, 100) < 4)
                    Destroy(collision.gameObject);
            }

            if (isBurningCloak)                                                                     //불화살 스킬 불타는 망토 관련 코드. 비효율적이다.
                collision.gameObject.layer = LayerMask.NameToLayer("Servant_Burned");               //불타는 망토 스킬체크 시 화상상태로 만듦.

            if (Random.Range(1, 100) < Player_Stat.instance.missPercent)                            //회피했을 시
            {
                this.gameObject.layer = LayerMask.NameToLayer("Player_Damaged");
                isDodge = true;
                StartCoroutine("Dodge");
            }
            else
            {
                //CameraShake.instance.cameraShake();   카메라 쉐이크 효과도 일단 삭제.
                if (Player_Stat.instance.armor >= collision.gameObject.GetComponent<Zombie_Stat>().Power)
                    Player_Stat.instance.health -= 2;
                else
                    Player_Stat.instance.health -= (collision.gameObject.GetComponent<Zombie_Stat>().Power - Player_Stat.instance.armor);
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
        yield return new WaitForSeconds(dashCool);
        DashIconCache.GetComponent<Image>().color = available;
        Can_Dash = true;
    }
    IEnumerator DashCoolForMaster()
    {
        yield return new WaitForSeconds(dashCool - 10);
        DashIconCache.GetComponent<Image>().color = available;
        Can_Dash = true;
    }
    IEnumerator Dodge()
    {
        yield return new WaitForEndOfFrame();
        isDodge = false;
    }
}

