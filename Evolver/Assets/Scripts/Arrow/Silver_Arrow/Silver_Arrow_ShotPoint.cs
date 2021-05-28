using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silver_Arrow_ShotPoint : MonoBehaviour
{ 
    Vector3 shootDirection; Vector3 shootDirection2; //public GameObject Silver_Arrow;     public GameObject Immed_Silver_Arrow; 
    public float offset; bool Zero_Stamina; float EverySecond = 0f; float HoldingTime = 0f;
    float launchForce; public float increaseDamage; float increaseLaunchForce; bool ischanged; float chargingDamage; public float TempDMG; float TempLF;  float MaxDist = 15f;
    TrailRenderer tr;  public float DMGPercent;  float First;    float Second;  public float DSC;
    public bool concen; public bool Long_range;  public bool Penetrate;   public int Immediate_Shot_Count;   public int ISCMax = 999; public bool ISCAble; //스킬 관련 변수들
    public bool isImmed;    float DMG;  float DMGForCrit;    GameObject temp;   public bool isFlash;
    private void Start()
    {
        chargingDamage = Player_Stat.instance.Charge_Damage_Plus + 14;
        launchForce = Player_Stat.instance.launchForce;
        tr = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        DSC = Player_Stat.instance.Decrease_Stamina_When_Bow_Charge;
        
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; 
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);

        if (Input.GetMouseButton(0))
        {
            if (Penetrate)
            {
                EverySecond += Time.deltaTime * 1.2f;
                HoldingTime += Time.deltaTime * 1.2f;
            }
            else
            {
                EverySecond += Time.deltaTime;
                HoldingTime += Time.deltaTime;
            }
            First = Player_Stat.instance.stamina;
            Player_Stat.instance.stamina -= (4.5f * DSC) * Time.deltaTime;                      //은화살은 스테미나 소모가 가장 크다.
            if (Player_Stat.instance.stamina < 0 && !Zero_Stamina && HoldingTime > 0.4f)
            {
                Second = Player_Stat.instance.stamina;
                if(concen)
                increaseDamage += (First - Second); 
                Shoot();
                HoldingTime = 0f;
                EverySecond = 0f;
                increaseDamage = 0f;
                increaseLaunchForce = 0f;
                Zero_Stamina = true;
            }

            if (((int)HoldingTime % 1 == 0 && HoldingTime > 1f) && HoldingTime <= 3.5f && !ischanged)
            {
                ischanged = true;
                increaseLaunchForce += 3;
                increaseDamage += chargingDamage;
            }

            if ((int)EverySecond >= 1)
            {
                EverySecond = 0;
                ischanged = false;
            }
        }
        if (Input.GetMouseButtonUp(0) && !Zero_Stamina)
        {
            if (HoldingTime < 0.4f)
                HoldingTime = 0;                        //block continued arrow shot when stamina is nearly zero
            else
            {
                Second = Player_Stat.instance.stamina;
                if (concen)
                    increaseDamage += (First - Second);
                Shoot();
                HoldingTime = 0f;
                EverySecond = 0f;
                increaseDamage = 0f;
                increaseLaunchForce = 0f;
            }
        }
        if (Zero_Stamina && !Input.GetMouseButton(0))
            Zero_Stamina = false;


        
    }


    public void Shoot()
    {
        shootDirection = Input.mousePosition;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();                 


        float degree = Mathf.Atan2(difference.y, difference.x);
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;
        //shootDirection.x = (float)2f * Mathf.Cos(degree);                       
        //shootDirection.y = (float)2f * Mathf.Sin(degree);

        GameObject new_Silver_Arrow = Instantiate(Resources.Load("Silver_Arrow"), transform.position, this.transform.rotation) as GameObject;
        new_Silver_Arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * (200f),
           shootDirection.y * (200f));
        RayAll();
    }

   void RayAll()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, shootDirection, MaxDist);
        DMGPercent = 10f;
        Immediate_Shot_Count = 0;
        for (int i = 0; i<hits.Length; i++)
        {
            RaycastHit2D hit = hits[i];
            if (hit.transform.tag == "Enemy" && DMGPercent > 0f)
            {
                Vector3 vec = new Vector3(hit.transform.position.x, hit.transform.position.y + 0.5f, 0f);
                if (Long_range && hit.distance > 4f)                    //장거리 사격 스킬체크시 increaseDamage에 플레이어 스탯의 데미지를 더해준다.
                {
                    increaseDamage += Player_Stat.instance.damage;
                }

                if (Random.Range(0, 100) < Player_Stat.instance.criticalPercent)            //크리티컬 카운트 ++, 즉발사격 Update 함수에서 우클릭 시 즉발사격 가능하게 구현하기
                {                                                                           // +무기 색깔 바꾸기
                    // # 발광화살 스킬 체크라면
                    if (isFlash)
                        if(Random.Range(0,100) < 20)
                            hit.transform.gameObject.layer = LayerMask.NameToLayer("Servant_Burned");
                    // # 관통 3강 스킬 체크라면
                    if (Player_Stat.instance.is_Penetrate3)
                        Player_Stat.instance.stamina += 20;
                    Immediate_Shot_Count++;
                    DMGForCrit = ((increaseDamage + Player_Stat.instance.damage) * (float)(0.1f * DMGPercent)) * (float)(Player_Stat.instance.criticalDamage / 100);
                    hit.transform.GetComponent<Zombie_Stat>().Health -= DMGForCrit;
                    temp = Instantiate(Resources.Load("FloatingParentsForCrit"), vec, Quaternion.identity) as GameObject;
                    temp.transform.GetChild(0).GetComponent<TextMesh>().text = DMGForCrit.ToString();
                    CameraShake.instance.cameraShake();
                }
                else
                {
                   
                    DMG = (increaseDamage + Player_Stat.instance.damage) * (float)(0.1f * DMGPercent);
                    hit.transform.GetComponent<Zombie_Stat>().Health -= DMG;
                    temp = Instantiate(Resources.Load("FloatingParents"), vec, Quaternion.identity) as GameObject;
                    temp.transform.GetChild(0).GetComponent<TextMesh>().text = DMG.ToString();

                }
                DMGPercent -= 1f;
            }
        }
        if (Immediate_Shot_Count > ISCMax && isImmed)
        {
            ISCAble = true;
            TempDMG = increaseDamage;
        }     
    }


    public void Shoot(float TempDMG)
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();


        float degree = Mathf.Atan2(difference.y, difference.x);
        shootDirection2 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        shootDirection2.x = (float)2f * Mathf.Cos(degree);
        shootDirection2.y = (float)2f * Mathf.Sin(degree);

        GameObject new_Silver_Arrow = Instantiate(Resources.Load("Silver_Arrow_For_ImmedShot"), transform.position, this.transform.rotation) as GameObject;
        new_Silver_Arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection2.x * (200f),
           shootDirection2.y * (200f));
        RayAll(TempDMG);
    }

    void RayAll(float TempDMG)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, shootDirection2, MaxDist);
        DMGPercent = 10f;
        Immediate_Shot_Count = 0;
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit2D hit = hits[i];
            if (hit.transform.tag == "Enemy" && DMGPercent > 0f)
            {
                Vector3 vec = new Vector3(hit.transform.position.x, hit.transform.position.y + 0.5f, 0f);
                if (Long_range && hit.distance > 4f)                    //장거리 사격 스킬체크시 increaseDamage에 플레이어 스탯의 데미지를 더해준다.
                {
                    TempDMG += Player_Stat.instance.damage;
                }

                if (Random.Range(0, 100) < Player_Stat.instance.criticalPercent)            //크리티컬 카운트 ++, 즉발사격 Update 함수에서 우클릭 시 즉발사격 가능하게 구현하기
                {                                                                           // +무기 색깔 바꾸기
                    if (isFlash)
                        if (Random.Range(0, 100) < 20)
                            hit.transform.gameObject.layer = LayerMask.NameToLayer("Servant_Burned");
                    if (Player_Stat.instance.is_Penetrate3)
                        Player_Stat.instance.stamina += 20;
                        Immediate_Shot_Count++;
                    DMGForCrit = (TempDMG * (float)(0.1f * DMGPercent)) * (float)(Player_Stat.instance.criticalDamage / 100);
                    hit.transform.GetComponent<Zombie_Stat>().Health -= DMGForCrit;
                    temp = Instantiate(Resources.Load("FloatingParentsForCrit"), vec, Quaternion.identity) as GameObject;
                    temp.transform.GetChild(0).GetComponent<TextMesh>().text = DMGForCrit.ToString();
                    CameraShake.instance.cameraShake();
                }
                else
                {
                    DMG = TempDMG * (float)(0.1f * DMGPercent);
                    hit.transform.GetComponent<Zombie_Stat>().Health -= DMG;
                    temp = Instantiate(Resources.Load("FloatingParents"), vec, Quaternion.identity) as GameObject;
                    temp.transform.GetChild(0).GetComponent<TextMesh>().text = DMG.ToString();
                }
                DMGPercent -= 1f;
            }
        }
        if (Immediate_Shot_Count > ISCMax && isImmed)
        {
            ISCAble = true;
            TempDMG = increaseDamage;
        }
    }

}
